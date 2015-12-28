using System;
using System.IO;

using NLog;

using FAHLogStats.Instrumentation;

using Majestic12;

/*

Copyright (c) Alex Chudnovsky, Majestic-12 Ltd (UK). 2005+ All rights reserved
Web:		http://www.majestic12.co.uk
E-mail:		alexc@majestic12.co.uk

Redistribution and use in source and binary forms, with or without modification, are 
permitted provided that the following conditions are met:

    * Redistributions of source code must retain the above copyright notice, this list of conditions 
		and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright notice, this list of conditions 
		and the following disclaimer in the documentation and/or other materials provided with the distribution.
    * Neither the name of the Majestic-12 nor the names of its contributors may be used to endorse or 
		promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, 
INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE 
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, 
SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

*/

namespace Majestic12
{
	/// <summary>
	/// HTMLparserTest: example of use of the HTML parser object
	/// </summary>
	class HTMLparserTest
	{
        private static Logger ClassLogger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// If true then an ENTER will be required when running this test in interactive mode (default)
		/// This mode can be switched off via command line switch NODELAY
		/// </summary>
		bool bReadLineDelay=true;

		/// <summary>
		/// If you don't know what this function is, then its probably best for you not to proceed.
		/// 
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			HTMLparserTest oT=new HTMLparserTest();
            DateTime Start = Debug.ExecStart;

			try
			{
				// check if we need to benchmark it 
				int iParseTimes=1;

				string sCurDir="";

				// parse command line for options
				if(args.Length>0)
				{
					string sCmdParam="-c=";

					// check for no delay sign
					for(int i=0; i<args.Length; i++)
					{
						// check if working directory is specified in command line
						if(args[i].StartsWith(sCmdParam))
						{
							sCurDir=args[i].Substring(sCmdParam.Length,args[i].Length-sCmdParam.Length);
							continue;
						}

						if(args[i].ToLower().Trim()=="nodelay")
							oT.bReadLineDelay=false;
						else
						{
							// must be benchmark number
							try
							{
								iParseTimes=int.Parse(args[i]);

                                ClassLogger.Log(LogLevel.Trace, String.Format("{0} Execution Time: {1}", Debug.FunctionName, Debug.GetExecTime(Start)), "");
                                // Console.WriteLine("Running benchmark parsing {0} times", iParseTimes);
							}
							catch (Exception Ex)
							{
                                ClassLogger.LogException(LogLevel.Warn, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
                                // Console.WriteLine("Benchmark number={0} is incorrect - should be integer", args[i]);
								return;
							}

						}
					}

				}

				// during debugging current directory will be in \bin\debug, so we will fix it here
				// to be where the source code is to be able to open file without having to hard code directory
				// either into project or code
				if(sCurDir!="")
				{
					Directory.SetCurrentDirectory(sCurDir);
				}
				else
				{

					sCurDir=Directory.GetCurrentDirectory().ToLower();
					int iIdx=sCurDir.IndexOf(@"bin\debug");

					if(iIdx==-1)
						iIdx=sCurDir.IndexOf(@"bin\release");

					if(iIdx!=-1)
					{
						sCurDir=sCurDir.Substring(0,iIdx);
						Directory.SetCurrentDirectory(sCurDir);
					}
				}
				// now parse HTML
				oT.Start(iParseTimes);
			}
			catch(Exception oEx)
			{
                ClassLogger.LogException(LogLevel.Warn, String.Format("{0} threw exception {1}.", Debug.FunctionName, oEx.Message), null);
                //Console.WriteLine("Exception: " + oEx);
			}

			// execute a delay if we are running in interactive or benchmark mode
            //if(oT.bReadLineDelay)
            //{
                //Console.WriteLine("Press ENTER to finish the program");
				//Console.ReadLine();
            //}
		}

		HTMLparserTest()
		{
		}

		/// <summary>
		/// Starts parsing
		/// </summary>
		/// <param name="iParseTimes">Number of times to parse document (useful for benchmarking)</param>
		void Start(int iParseTimes)
		{
			string sFileName=Path.Combine(Directory.GetCurrentDirectory(),"tests"+Path.DirectorySeparatorChar+"majestic12.html");

			if(!File.Exists(sFileName))
			{
				Console.WriteLine("Could not find file in current directory to parse - expected it to be here: "+sFileName);
				return;
			}

			HTMLparser oP=new HTMLparser();

			// This is optional, but if you want high performance then you may
			// want to set chunk hash mode to FALSE. This would result in tag params
			// being added to string arrays in HTMLchunk object called sParams and sValues, with number
			// of actual params being in iParams. See code below for details.
			//
			// When TRUE (and its default) tag params will be added to hashtable HTMLchunk (object).oParams
			oP.SetChunkHashMode(false);

			// if you set this to true then original parsed HTML for given chunk will be kept - 
			// this will reduce performance somewhat, but may be desireable in some cases where
			// reconstruction of HTML may be necessary
			oP.bKeepRawHTML=false;

			// load HTML from file
			oP.LoadFromFile(sFileName);

			DateTime oStart=DateTime.Now;

			for(int i=0; i<iParseTimes; i++)
			{
				if(iParseTimes>1)
					BenchMarkParse(oP);
				else
					ParseAndPrint(oP);


				oP.Reset();
			}

			// calculate number of milliseconds we were parsing
			int iMSecs=(int)((DateTime.Now.Ticks-oStart.Ticks)/TimeSpan.TicksPerMillisecond);

			if(iMSecs>0 && iParseTimes>0)
			{
				Console.WriteLine("Parsed {0} time(s), total time {1} secs, approximately {2} ms per full parse.",iParseTimes,iMSecs/1000,iMSecs/iParseTimes);
			}

			oP.Close();
		
		}

		/// <summary>
		/// Parse for benchmarking purposes -- its pure test of HTML parsing object, no extra processing done here
		/// </summary>
		/// <param name="oP">Parser object</param>
		void BenchMarkParse(HTMLparser oP)
		{
			// parser will return us tokens called HTMLchunk -- warning DO NOT destroy it until end of parsing
			// because HTMLparser re-uses this object
			HTMLchunk oChunk=null;

			// we parse until returned oChunk is null indicating we reached end of parsing
			while((oChunk=oP.ParseNext())!=null)
			{
				switch(oChunk.oType)
				{
						// matched open tag, ie <a href="">
					case HTMLchunkType.OpenTag:
						break;

						// matched close tag, ie </a>
					case HTMLchunkType.CloseTag:
						break;

						// matched normal text
					case HTMLchunkType.Text:
						break;

						// matched HTML comment, that's stuff between <!-- and -->
					case HTMLchunkType.Comment:
						break;
				};
			}

		}

		
		/// <summary>
		/// Parses HTML by chunk, prints parsed data on screen and waits for ENTER to go to next chunk
		/// </summary>
		/// <param name="oP">Parser object</param>
		void ParseAndPrint(HTMLparser oP)
		{
			if(bReadLineDelay)
				Console.WriteLine("Parsing HTML, will print each parsed chunk, press ENTER after each to continue");

			// parser will return us tokens called HTMLchunk -- warning DO NOT destroy it until end of parsing
			// because HTMLparser re-uses this object
			HTMLchunk oChunk=null;

			// we parse until returned oChunk is null indicating we reached end of parsing
			while((oChunk=oP.ParseNext())!=null)
			{
				switch(oChunk.oType)
				{
						// matched open tag, ie <a href="">
					case HTMLchunkType.OpenTag:
						Console.Write("Open tag: "+oChunk.sTag);

						// lets get params and their values

						// if hashmode is set then param/values are kept in Hashtable oChunk.oParams
						// this makes parsing slower, so if you want the highest performance then you 
						// need to HashMode to false
						if(oChunk.bHashMode)
						{
							if(oChunk.oParams.Count>0)
							{
								foreach(string sParam in oChunk.oParams.Keys)
								{
									string sValue=oChunk.oParams[sParam].ToString();

									if(sValue.Length>0)
										Console.Write(" {0}='{1}'",sParam,sValue);
									else
										Console.Write(" {0}",sParam);
								}

							}
						}
						else
						{
							// this is alternative method of getting params -- it may look less convinient
							// but it saves a LOT of CPU ticks while parsing. It makes sense when you only need
							// params for a few
							if(oChunk.iParams>0)
							{
								for(int i=0; i<oChunk.iParams; i++)
								{
									if(oChunk.sValues[i].Length>0)
										Console.Write(" {0}='{1}'",oChunk.sParams[i],oChunk.sValues[i]);
									else
										Console.Write(" {0}",oChunk.sParams[i]);
								}

							}
						
						}

						break;

						// matched close tag, ie </a>
					case HTMLchunkType.CloseTag:
						Console.Write("Closed tag: "+oChunk.sTag);
						break;

					// matched normal text
					case HTMLchunkType.Text:
						Console.Write("Text: '{0}'",oChunk.oHTML);
						break;

						// matched HTML comment, that's stuff between <!-- and -->
					case HTMLchunkType.Comment:
						
						// Note: you need to call finalisation on the chunk as by default comments are 
						// not finalised for performance reasons - if you have made parser to keep raw
						// HTML then you won't be needing to finalise it
						if(!oP.bKeepRawHTML)
							oChunk.Finalise();

						Console.Write("Comment: "+oChunk.oHTML);
						break;
				};

				if(bReadLineDelay)
					Console.ReadLine();
				else
					Console.WriteLine("");
			}

		}

	}
}
