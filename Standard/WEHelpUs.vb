Imports System.ComponentModel
Imports System.Text
Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements
Imports openElement.WebElement.LinksManager
Imports openElement.WebElement.StylesManager

Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Standard

    <Serializable> _
    Public Class WEHelpUs
        Inherits ElementBase

        #Region "Fields"

        Private _DefaultText As String = LocalizablePropertyDefaultValue._0003
        Private _ImageEmptyLink As Link
        Private _Text As LocalizableHtml

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEHelpUs", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Browsable(False)> _
        Public Property ImageEmptyLink() As Link
            Get
                If _ImageEmptyLink Is Nothing Then
                    _ImageEmptyLink = New Link()
                    MyBase.CreateAutoRessourceByBitmap(_ImageEmptyLink, Link.EnuLinkType.ElementImage, My.Resources.empty, "WEFiles/Image/empty.png")
                End If
                Return _ImageEmptyLink
            End Get
            Set(ByVal value As Link)
                _ImageEmptyLink = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N007"), _
        LocalizableDescAtt("_D007"), _
        Browsable(False), _
        TypeConverter(GetType(TConvLocalizableString))> _
        Public Property Text() As LocalizableHtml
            Get
                If _Text Is Nothing Then _Text = New LocalizableHtml(_DefaultText, MyBase.Page.Culture)
                Return _Text
            End Get
            Set(ByVal value As LocalizableHtml)
                _Text = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnDelete(ByVal actualDeteleAction As Boolean) As Boolean
            If MyBase.LockDelete Then OEMsgBox(LocalizableOpen._0219, MsgBoxType.Info)
            Return MyBase.OnDelete(actualDeteleAction)
        End Function

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0013
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupStandard"
            info.ToolBoxIco = My.Resources.WEHelpUs
            info.ToolBoxDescription = LocalizableOpen._0014
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("Image", LocalizableOpen._0015, LocalizableOpen._0016)) '"Image Principal" - '"Zone de l'image située à gauche du texte"
            configStylesZones.Add(New ConfigStylesZone("Text", LocalizableOpen._0017, LocalizableOpen._0018)) ' "Texte"  -   "Zone du texte principal"

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)
            Call RenderImage(writer)
            Call RenderText(writer)
            MyBase.RenderEndTag(writer)
        End Sub

        Private Function OEUrl() As Link
            Dim link As New Link()
            link.Target = New LinkTarget("_blank")

            Select Case Page.Culture.ToLower
                Case "fr"
                    link.UpdateLink(link.EnuLinkType.FreeUrl, "http://www.openelement.fr")
                Case Else
                    link.UpdateLink(link.EnuLinkType.FreeUrl, "http://www.openelement.com")
            End Select

            Return link
        End Function

        Private Sub RenderImage(ByRef writer As HtmlWriter)
            Dim cssEmptyImageBuilder As New StringBuilder()
            cssEmptyImageBuilder.Append(StylesUtils.ConcatCSSValue("width:", "100%", ";"))
            cssEmptyImageBuilder.Append(StylesUtils.ConcatCSSValue("height:", "100%", ";"))
            cssEmptyImageBuilder.Append(StylesUtils.ConcatCSSValue("border:", "none", ";"))

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", GetStyleZoneClass("Image"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.WriteBeginTag("a")
            writer.WriteAttribute("href", OEUrl.GetSitePath())
            writer.WriteAttribute("target", "_blank")
            writer.Write(HtmlTextWriter.TagRightChar)

            writer.WriteBeginTag("img")
            writer.WriteAttribute("src", MyBase.GetLink(ImageEmptyLink))
            writer.WriteAttribute("style", cssEmptyImageBuilder.ToString)
            writer.WriteAttribute("alt", _DefaultText)
            writer.Write(HtmlTextWriter.SelfClosingTagEnd)

            writer.WriteEndTag("a")
            writer.WriteLine()
            writer.WriteEndTag("div")
            writer.WriteLine()
        End Sub

        Private Sub RenderText(ByRef writer As HtmlWriter)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", GetStyleZoneClass("Text"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.WriteHtmlBlockLinkEdit(Me, "Text", False, OEUrl, True)

            writer.WriteLine()
            writer.WriteEndTag("div")
            writer.WriteLine()
        End Sub

        #End Region 'Methods

    End Class

End Namespace

