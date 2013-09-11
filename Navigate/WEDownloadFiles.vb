Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports WebElement.Elements.Form.Editors

Namespace WEElements.Navigate

    <Serializable()> _
Public Class WEDownloadFiles
        Inherits ElementBase

#Region "Properties"

        Private _AlternativeLabelText As DataType.LocalizableHtml
        Private _ImageLink As LinksManager.Link
        Private _DocumentLink As LinksManager.Link
        Private _ImagePosition As TextPosition

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N050"), _
        Ressource.localizable.LocalizableDescAtt("_D100"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ImagePosition() As TextPosition
            Get
                Return _ImagePosition
            End Get
            Set(ByVal value As TextPosition)
                _ImagePosition = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N002"), _
        Ressource.localizable.LocalizableDescAtt("_D008"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkFile), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
        Common.Attributes.ConfigBiblio(True, False, False, False, False)> _
        Public Property ImageLink() As LinksManager.Link
            Get
                If _ImageLink Is Nothing Then _ImageLink = New LinksManager.Link()
                Return _ImageLink
            End Get
            Set(ByVal value As LinksManager.Link)
                _ImageLink = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N003"), _
        Ressource.localizable.LocalizableDescAtt("_D009"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkFile), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element), _
        Common.Attributes.ConfigBiblio(True, True, True, True, True)> _
        Public Property DocumentLink() As LinksManager.Link
            Get
                If _DocumentLink Is Nothing Then _DocumentLink = New LinksManager.Link()
                Return _DocumentLink
            End Get
            Set(ByVal value As LinksManager.Link)
                value.Target = New LinkTarget("_blank")
                _DocumentLink = value
            End Set
        End Property

        <Browsable(False), _
       TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
       Public Property AlternativeLabelText() As DataType.LocalizableHtml
            Get
                If _AlternativeLabelText Is Nothing Then
                    _AlternativeLabelText = New DataType.LocalizableHtml(My.Resources.text.LocalizablePropertyDefaultValue._0004, MyBase.Page.Culture)
                End If
                Return _AlternativeLabelText
            End Get
            Set(ByVal value As DataType.LocalizableHtml)
                _AlternativeLabelText = value
            End Set
        End Property

#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEDownloadFiles", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0021
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupNavigate"
            info.ToolBoxIco = My.Resources.WEDownloadFiles
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0022
            info.AutoOpenProperty = "DocumentLink"
            info.SortPropertyList.Add(New SortProperty("DocumentLink", "link.png", My.Resources.text.LocalizableOpen._0024))
            info.SortPropertyList.Add(New SortProperty("ImageLink", "image.png", My.Resources.text.LocalizableOpen._0025)) 
            Return info

        End Function


        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Image", My.Resources.text.LocalizableOpen._0015, My.Resources.text.LocalizableOpen._0023))

            MyBase.OnOpen(configStylesZones)

        End Sub

#End Region

#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

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

        Private Sub RenderLinkImage(ByRef writer As Common.HtmlWriter, ByVal verticalAlign As String)
            Dim linkImage As String = MyBase.GetLink(Me.ImageLink)
            If Not String.IsNullOrEmpty(linkImage) Then
                writer.WriteBeginTag("a")
                writer.WriteHrefAttribute(Me, Me.DocumentLink, True)
                writer.Write(Web.UI.HtmlTextWriter.TagRightChar)
                writer.WriteBeginTag("img")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Image"))
                writer.WriteAttribute("style", "border:none; vertical-align: " & verticalAlign & " ;")
                writer.WriteAttribute("src", linkImage)
                writer.Write(Web.UI.HtmlTextWriter.SelfClosingTagEnd)
                writer.WriteEndTag("a")
            End If
        End Sub

        Private Sub RenderLinkdocument(ByRef writer As Common.HtmlWriter)
            writer.WriteHtmlBlockLinkEdit(Me, "AlternativeLabelText", False, Me.DocumentLink, True)
        End Sub

#End Region

    End Class

End Namespace
