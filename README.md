# Properties2XML
A simple command line tool for converting Java .properties files to .xml files

## Program usage
```bash
properties2xml --inPath path/to/properties/files --outPath path/to/xml/output/folder
```
## How it works
It splits the properties file at the 1st `=` and it converts that data to XML.
### Conversion xample

<table>
    <tr>
        <th>Properties file</th>
        <th>XML file</th>
    </tr>
    <tr>
        <td>
            <pre lang="properties">something1=Value1
something2=Value2
something3=Value3
something4=Value4</pre>
        </td>
        <td>
            <pre lang="xml">&lt;?xml version="1.0"?&gt;
&lt;Properties&gt;
    &lt;Property Name="something1"&gt;Value1&lt;/Property&gt;
    &lt;Property Name="something2"&gt;Value2&lt;/Property&gt;
    &lt;Property Name="something3"&gt;Value3&lt;/Property&gt;
    &lt;Property Name="something4"&gt;Value4&lt;/Property&gt;
&lt;/Properties&gt;</pre>
        </td>
    </tr>
</table>
