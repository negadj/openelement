Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Elements
Imports openElement.WebElement.StylesManager

Imports WebElement.My.Resources.text

Namespace Elements.Other

    <Serializable> _
    Public Class WEW3C
        Inherits ElementBase

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEW3C", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0232
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupOther"
            info.ToolBoxIco = My.Resources.WEW3C
            info.ToolBoxDescription = LocalizableOpen._0011
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            writer.WriteBeginTag("a")
            writer.WriteAttribute("href", "http://validator.w3.org/check?uri=referer&amp;doctype=XHTML+1.0+Transitional")
            writer.Write(HtmlTextWriter.TagRightChar)

            writer.WriteBeginTag("img")
            writer.WriteAttribute("src", MyBase.ConvertToRelativeLink("WEFiles/Image/WEW3C.png"))
            writer.WriteAttribute("alt", "Valid XHTML 1.0 Transitional")
            writer.WriteAttribute("height", "31")
            writer.WriteAttribute("width", "88")
            writer.WriteAttribute("style", "border-style:hidden")
            writer.Write(HtmlTextWriter.SelfClosingTagEnd)

            writer.WriteEndTag("a")

            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

