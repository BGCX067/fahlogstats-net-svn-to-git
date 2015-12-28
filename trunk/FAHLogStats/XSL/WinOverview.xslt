<?xml version="1.0" encoding="utf-8" ?>
<!DOCTYPE xsl:stylesheet [
	<!ENTITY nbsp "&#160;">
]><xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="Overview">
		<html>
			<head>
				<title>Folding System Overview</title>
				<link rel="stylesheet" type="text/css" href="file:///$APPPATH\CSS\$CSSFILE" />
			</head>
			<body>
				<table class="Overview" width="100%">
					<tr>
						<td class="Heading" width="35%">Overview</td>
						<td class="Blank"> </td>
					</tr>
					<tr>
						<td class="LeftCol">Total Folding Clients</td>
						<td class="RightCol">
							<xsl:value-of select="TotalHosts"/>
						</td>
					</tr>
					<tr>
						<td class="LeftCol">Working Clients</td>
						<td class="RightCol">
							<xsl:value-of select="GoodHosts"/>
						</td>
					</tr>
					<tr>
						<td class="LeftCol">Non-Working Clients</td>
						<td class="RightCol">
							<xsl:value-of select="BadHosts"/>
						</td>
					</tr>
					<tr>
						<td class="LeftCol">Total PPD (Working Clients)</td>
						<td class="RightCol">
							<xsl:value-of select="EstPPD"/>
						</td>
					</tr>
					<tr>
						<td class="LeftCol">Total PPW (Working Clients)</td>
						<td class="RightCol">
							<xsl:value-of select="EstPPW"/>
						</td>
					</tr>
					<tr>
						<td class="LeftCol">Total UPD (Working Clients)</td>
						<td class="RightCol">
							<xsl:value-of select="EstUPD"/>
						</td>
					</tr>
					<tr>
						<td class="LeftCol">Total UPW (Working Clients)</td>
						<td class="RightCol">
							<xsl:value-of select="EstUPW"/>
						</td>
					</tr>
					<tr>
						<td class="LeftCol">Average PPD (Working Clients)</td>
						<td class="RightCol">
							<xsl:value-of select="AvEstPPD"/>
						</td>
					</tr>
					<tr>
						<td class="LeftCol">Average<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>PPW<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>(Working<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>Clients)</td>
						<td class="RightCol">
							<xsl:value-of select="AvEstPPW"/>
						</td>
					</tr>
					<tr>
						<td class="LeftCol">Average<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>UPD<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>(Working<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>Clients)</td>
						<td class="RightCol">
							<xsl:value-of select="AvEstUPD"/>
						</td>
					</tr>
					<tr>
						<td class="LeftCol">Average<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>UPW<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>(Working<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>Clients)</td>
						<td class="RightCol">
							<xsl:value-of select="AvEstUPW"/>
						</td>
					</tr>
					<tr>
						<td class="LeftCol">Completed Units</td>
						<td class="RightCol">
							<xsl:value-of select="TotalCompleted"/>
						</td>
					</tr>
					<tr>
						<td class="Plain" colspan="2" align="center">
							Page rendered on <xsl:value-of select="LastUpdatedDate"/>
							at <xsl:value-of select="LastUpdatedTime"/>
						</td>
					</tr>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>