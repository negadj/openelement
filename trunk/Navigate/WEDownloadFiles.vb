Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements
Imports openElement.WebElement.LinksManager
Imports openElement.WebElement.StylesManager

Imports WebElement.Elements.Form.Editors
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace WEElements.Navigate

    <Serializable> _
    Public Class WEDownloadFiles
        Inherits ElementBase

        #Region "Fields"

        Private _AlternativeLabelText As LocalizableHtml
        Private _DocumentLink As Link
        Private _ImageLink As Link
        Private _ImagePosition As TextPosition

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEDownloadFiles", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Browsable(False), _
        TypeConverter(GetType(TConvLocalizableString)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property AlternativeLabelText() As LocalizableHtml
            Get
                If _AlternativeLabelText Is Nothing Then
                    _AlternativeLabelText = New LocalizableHtml(LocalizablePropertyDefaultValue._0004, MyBase.Page.Culture)
                End If
                Return _AlternativeLabelText
            End Get
            Set(ByVal value As LocalizableHtml)
                _AlternativeLabelText = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N003"), _
        LocalizableDescAtt("_D009"), _
        Editor(GetType(UITypeLinkFile), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element), _
        ConfigBiblio(True, True, True, True, True)> _
        Public Property DocumentLink() As Link
            Get
                If _DocumentLink Is Nothing Then _DocumentLink = New Link()
                Return _DocumentLink
            End Get
            Set(ByVal value As Link)
                value.Target = New LinkTarget("_blank")
                _DocumentLink = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N002"), _
        LocalizableDescAtt("_D008"), _
        Editor(GetType(UITypeLinkFile), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element), _
        ConfigBiblio(True, False, False, False, False)> _
        Public Property ImageLink() As Link
            Get
                If _ImageLink Is Nothing Then _ImageLink = New Link()
                Return _ImageLink
            End Get
            Set(ByVal value As Link)
                _ImageLink = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N050"), _
        LocalizableDescAtt("_D100"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ImagePosition() As TextPosition
            Get
                Return _ImagePosition
            End Get
            Set(ByVal value As TextPosition)
                _ImagePosition = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0021
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupNavigate"
            info.ToolBoxIco = My.Resources.WEDownloadFiles
            info.ToolBoxDescription = LocalizableOpen._0022
            info.AutoOpenProperty = "DocumentLink"
            info.SortPropertyList.Add(New SortProperty("DocumentLink", "link.png", LocalizableOpen._0024))
            info.SortPropertyList.Add(New SortProperty("ImageLink", "image.png", LocalizableOpen._0025))
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("Image", LocalizableOpen._0015, LocalizableOpen._0023))

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            Select Case ImagePosition

                Case TextPosition.top
                    Call RenderLinkImage(writer, "none;display:block;")
                    Call RenderLinkdocument(writer)

                Case TextPosition.bottom
                    Call RenderLinkdocument(writer)
                    Call RenderLinkImage(writer, "none;display:block;")

                Case TextPosition.leftbottom
                    Call RenderLinkImage(writer, "bottom")
                    Call RenderLinkdocument(writer)

                Case TextPosition.leftmiddle
                    Call RenderLinkImage(writer, "middle")
                    Call RenderLinkdocument(writer)

                Case TextPosition.lefttop
                    Call RenderLinkImage(writer, "top")
                    Call RenderLinkdocument(writer)

                Case TextPosition.rightbottom
                    Call RenderLinkdocument(writer)
                    Call RenderLinkImage(writer, "bottom")

                Case TextPosition.rightmiddle
                    Call RenderLinkdocument(writer)
                    Call RenderLinkImage(writer, "middle")

                Case TextPosition.righttop
                    Call RenderLinkdocument(writer)
                    Call RenderLinkImage(writer, "top")

            End Select

            MyBase.RenderEndTag(writer)
        End Sub

        Private Sub RenderLinkdocument(ByRef writer As HtmlWriter)
            writer.WriteHtmlBlockLinkEdit(Me, "AlternativeLabelText", False, Me.DocumentLink, True)
        End Sub

        Private Sub RenderLinkImage(ByRef writer As HtmlWriter, ByVal verticalAlign As String)
            Dim linkImage As String = MyBase.GetLink(Me.ImageLink)
            If Not String.IsNullOrEmpty(linkImage) Then
                writer.WriteBeginTag("a")
                writer.WriteHrefAttribute(Me, Me.DocumentLink, True)
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.WriteBeginTag("img")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Image"))
                writer.WriteAttribute("style", "border:none; vertical-align: " & verticalAlign & " ;")
                writer.WriteAttribute("src", linkImage)
                writer.Write(HtmlTextWriter.SelfClosingTagEnd)
                writer.WriteEndTag("a")
            End If
        End Sub

        #End Region 'Methods

    End Class

End Namespace

