Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Elements
Imports openElement.WebElement.StylesManager

Imports WebElement.My.Resources.text

Namespace Elements.Form

    <Serializable> _
    Public Class WEHr
        Inherits ElementBase

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEHrLign", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Width
        End Sub

        #End Region 'Constructors

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0011
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupStandard"
            info.ToolBoxIco = My.Resources.WEHr
            info.ToolBoxDescription = LocalizableOpen._0012
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("Deco1", LocalizableOpen._0140, LocalizableOpen._0141))
            configStylesZones.Add(New ConfigStylesZone("Deco2", LocalizableOpen._0142, LocalizableOpen._0143))
            configStylesZones.Add(New ConfigStylesZone("Deco3", LocalizableOpen._0144, LocalizableOpen._0144))

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Deco1"))
            writer.WriteAttribute("style", "position:absolute")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Deco2"))
            writer.WriteAttribute("style", "position:absolute")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Deco3"))
            writer.WriteAttribute("style", "position:absolute")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

