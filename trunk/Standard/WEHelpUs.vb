Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.StylesManager
Imports System.Text

Namespace Elements.Standard


    <Serializable()> _
    Public Class WEHelpUs
        Inherits ElementBase

#Region "Properties"

        Private DEFAULTTEXT As String = My.Resources.text.LocalizablePropertyDefaultValue._0003

        Private _Text As DataType.LocalizableHtml
        Private _ImageEmptyLink As LinksManager.Link

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N007"), _
        Ressource.localizable.LocalizableDescAtt("_D007"), _
        Browsable(False), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString))> _
        Public Property Text() As DataType.LocalizableHtml
            Get
                If _Text Is Nothing Then _Text = New DataType.LocalizableHtml(DEFAULTTEXT, MyBase.Page.Culture)
                Return _Text
            End Get
            Set(ByVal value As DataType.LocalizableHtml)
                _Text = value
            End Set
        End Property

        <Browsable(False)> _
        Public Property ImageEmptyLink() As LinksManager.Link
            Get
                If _ImageEmptyLink Is Nothing Then
                    _ImageEmptyLink = New LinksManager.Link()
                    MyBase.CreateAutoRessourceByBitmap(_ImageEmptyLink, LinksManager.Link.EnuLinkType.ElementImage, My.Resources.empty, "WEFiles/Image/empty.png")
                End If
                Return _ImageEmptyLink
            End Get
            Set(ByVal value As LinksManager.Link)
                _ImageEmptyLink = value
            End Set
        End Property

#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEHelpUs", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0013
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupStandard"
            info.ToolBoxIco = My.Resources.WEHelpUs
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0014
            Return info

        End Function

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("Image", My.Resources.text.LocalizableOpen._0015, My.Resources.text.LocalizableOpen._0016)) '"Image Principal" - '"Zone de l'image située à gauche du texte"
            configStylesZones.Add(New ConfigStylesZone("Text", My.Resources.text.LocalizableOpen._0017, My.Resources.text.LocalizableOpen._0018)) ' "Texte"  -   "Zone du texte principal"

            MyBase.OnOpen(configStylesZones)
        End Sub

#End Region

        Protected Overrides Function OnDelete(ByVal actualDeteleAction As Boolean) As Boolean
            If MyBase.LockDelete Then OEMsgBox(My.Resources.text.LocalizableOpen._0219, MsgBoxType.Info)
            Return MyBase.OnDelete(actualDeteleAction)
        End Function

        Private Function OEUrl() As LinksManager.Link
            Dim link As New LinksManager.Link()
            link.Target = New LinkTarget("_blank")

            Select Case Page.Culture.ToLower
                Case "fr"
                    link.UpdateLink(LinksManager.Link.EnuLinkType.FreeUrl, "http://www.openelement.fr")
                Case Else
                    link.UpdateLink(LinksManager.Link.EnuLinkType.FreeUrl, "http://www.openelement.com")
            End Select

            Return link

        End Function

#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)
            Call RenderImage(writer)
            Call RenderText(writer)
            MyBase.RenderEndTag(writer)

        End Sub

        Private Sub RenderText(ByRef writer As Common.HtmlWriter)

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", GetStyleZoneClass("Text"))
            writer.Write(Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.WriteHtmlBlockLinkEdit(Me, "Text", False, OEUrl, True)

            writer.WriteLine()
            writer.WriteEndTag("div")
            writer.WriteLine()

        End Sub

        Private Sub RenderImage(ByRef writer As Common.HtmlWriter)

            Dim cssEmptyImageBuilder As New StringBuilder()
            cssEmptyImageBuilder.Append(StylesUtils.ConcatCSSValue("width:", "100%", ";"))
            cssEmptyImageBuilder.Append(StylesUtils.ConcatCSSValue("height:", "100%", ";"))
            cssEmptyImageBuilder.Append(StylesUtils.ConcatCSSValue("border:", "none", ";"))

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", GetStyleZoneClass("Image"))
            writer.Write(Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.WriteBeginTag("a")
            writer.WriteAttribute("href", OEUrl.GetSitePath())
            writer.WriteAttribute("target", "_blank")
            writer.Write(Web.UI.HtmlTextWriter.TagRightChar)

            writer.WriteBeginTag("img")
            writer.WriteAttribute("src", MyBase.GetLink(ImageEmptyLink))
            writer.WriteAttribute("style", cssEmptyImageBuilder.ToString)
            writer.WriteAttribute("alt", DEFAULTTEXT)
            writer.Write(Web.UI.HtmlTextWriter.SelfClosingTagEnd)

            writer.WriteEndTag("a")
            writer.WriteLine()
            writer.WriteEndTag("div")
            writer.WriteLine()

        End Sub

#End Region

    End Class
End Namespace