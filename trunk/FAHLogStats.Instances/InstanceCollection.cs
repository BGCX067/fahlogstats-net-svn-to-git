/*
 * FAHLogStats.NET - Instance Collection Helper Class
 * Copyright (C) 2006-2007 David Rawling

 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; version 2
 * of the License. See the included file GPLv2.TXT.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using System;
using System.Xml;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FAHLogStats.Instances
{
    public class FoldingInstanceCollection : Dictionary<String, Base>
    {
        /// <summary>
        /// Loads a collection of Host Instances from disk
        /// </summary>
        /// <param name="xmlDocName">Filename (verbatim) to load data from - User AppData Path is prepended
        /// if the path does not start with either ?: or \\</param>
        public virtual void FromXml(String xmlDocName)
        {
            System.Xml.XmlDocument xmlData = new System.Xml.XmlDocument();

            // Save the XML stream to the file
            if ((xmlDocName.Substring(1,1) == ":") || (xmlDocName.StartsWith("\\\\")))
            {
                xmlData.Load(xmlDocName);
            }
            else
            {
                xmlData.Load(Preferences.PreferenceSet.Instance.AppDataPath + "\\" + xmlDocName);
            }
            
            // xmlData now contains the collection of Nodes. Hopefully.
            xmlData.RemoveChild(xmlData.ChildNodes[0]);

            foreach (XmlNode xn in xmlData.ChildNodes[0])
            {
                String _InstanceType = xn.SelectSingleNode("HostType").InnerText;
                // Create new object of type "this.namespace" + _InstanceType

                // Load the type called for by the XML
                Type t = Type.GetType(_InstanceType);
                // Create the array of parameters for the fromXml call
                System.Xml.XmlNode[] paramData = new System.Xml.XmlNode[1];
                // Set the parameter array element to the XML data from above
                paramData[0] = xn;
                // Create an instance of the object
                object o = Activator.CreateInstance(t);
                // Locate the FromXml method - must exist for our hierarchy
                MethodInfo mi = t.GetMethod("FromXml");
                // Call the FromXml method - deserialize
                mi.Invoke(o, paramData);
                // Add the new object to our collection
                this.Add(((Base)o).Name, (Base)o);
            }
        }

        /// <summary>
        /// Saves the current collection of Host Instances to disk
        /// </summary>
        /// <param name="xmlDocName">Filename (verbatim) to save data to - User AppData Path is prepended
        /// if the path does not start with either ?: or \\</param>
        public virtual void ToXml(String xmlDocName)
        {
            System.Xml.XmlDocument xmlData = new System.Xml.XmlDocument();

            // Create the XML Declaration (well formed)
            XmlDeclaration xmlDeclaration = xmlData.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlData.InsertBefore(xmlDeclaration, xmlData.DocumentElement);

            // Create the root element
            System.Xml.XmlElement xmlRoot = xmlData.CreateElement("Hosts");

            // Loop through the collection and serialize the lot
            foreach (KeyValuePair<String, Base> de in this)
            {
                Base fi = (Base) de.Value;
                XmlDocument xmlDoc = fi.ToXml();

                foreach (XmlNode xn in xmlDoc.ChildNodes)
                    xmlRoot.AppendChild(xmlData.ImportNode(xn, true));
                }
            xmlData.AppendChild(xmlRoot);

            // Save the XML stream to the file
            if ((xmlDocName.Substring(1,1) == ":") || (xmlDocName.StartsWith("\\\\")))
            {
                xmlData.Save(xmlDocName);
            }
            else
            {
                xmlData.Save(Preferences.PreferenceSet.Instance.AppDataPath + "\\" + xmlDocName);
            }
        }
    
    }
}
