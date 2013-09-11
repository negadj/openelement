Imports openElement.WebElement.Elements
Imports openElement.WebElement


Namespace Elements.Standard

    ''' <summary>
    ''' this element is just a graphic element. 
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class WECadre
        Inherits ElementBase

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WECadre", page, parentID, templateName)
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0191
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupStandard"
            info.ToolBoxIco = My.Resources.WECadre
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0192
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim ConfigStylesZones As New List(Of StylesManager.ConfigStylesZone)
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Top", My.Resources.text.LocalizableOpen._0193, My.Resources.text.LocalizableOpen._0194))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Content", My.Resources.text.LocalizableOpen._0195, My.Resources.text.LocalizableOpen._0196))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Bottom", My.Resources.text.LocalizableOpen._0197, My.Resources.text.LocalizableOpen._0198))

            MyBase.OnOpen(ConfigStylesZones)
        End Sub

#End Region

#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Top"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Content"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Bottom"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            MyBase.RenderEndTag(writer)
        End Sub

#End Region

    End Class

End Namespace