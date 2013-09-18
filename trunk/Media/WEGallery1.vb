Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Web.UI
Imports System.Windows.Forms

Imports openElement
Imports openElement.Tools
Imports openElement.WebElement
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Control
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements
Imports openElement.WebElement.LinksManager
Imports openElement.WebElement.StylesManager

Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Imports Path = System.IO.Path

Namespace Elements.Media

    <Serializable> _
    Public Class WEGallery1
        Inherits ElementBase

        #Region "Fields"

        Private _AutoStart As Boolean
        <ContainsLinks> _
        Private _ConfigImages As GalleryImages
        Private _Delay As Integer
        Private _ElemSize As ElementSize
        Private _JpgBackColor As Color
        Private _NextLinkText As LocalizableString
        Private _NumThumbs As Integer
        Private _PauseLinkText As LocalizableString
        Private _PlayLinkText As LocalizableString
        Private _PrevLinkText As LocalizableString
        Private _RenderNavControls As Boolean
        Private _RenderSSControls As Boolean
        Private _ResizeAllPictures As Boolean

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEGallery1", page, parentID, templateName)
            RenderNavControls = True
            RenderSSControls = True
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N090"), _
        LocalizableDescAtt("_D091"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property AutoStart() As Boolean
            Get
                Return _AutoStart
            End Get
            Set(ByVal value As Boolean)
                _AutoStart = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N001"), _
        LocalizableDescAtt("_D083"), _
        Editor(GetType(UITypeEditListOf), GetType(UITypeEditor)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property ConfigImages() As GalleryImages
            Get
                If _ConfigImages Is Nothing Then _ConfigImages = New GalleryImages
                Return _ConfigImages
            End Get
            Set(ByVal value As GalleryImages)
                _ConfigImages = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N083"), _
        LocalizableDescAtt("_D084"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Delay() As Integer
            Get
                If _Delay = 0 Then _Delay = 2000
                Return _Delay
            End Get
            Set(ByVal value As Integer)
                _Delay = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N136"), _
        LocalizableDescAtt("_D136"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property JpgBackColor() As Color
            Get
                Return _JpgBackColor
            End Get
            Set(ByVal value As Color)
                _JpgBackColor = value
                ResizeAllPictures = True
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N086"), _
        LocalizableDescAtt("_D087"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property NextLinkText() As LocalizableString
            Get
                If _NextLinkText Is Nothing Then _NextLinkText = New LocalizableString(LocalizableOpen._0397)
                Return _NextLinkText
            End Get
            Set(ByVal value As LocalizableString)
                _NextLinkText = value 'Formatage fait par gallerific
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N084"), _
        LocalizableDescAtt("_D085"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property NumThumbs() As Integer
            Get
                If _NumThumbs = 0 Then _NumThumbs = 8
                Return _NumThumbs
            End Get
            Set(ByVal value As Integer)
                _NumThumbs = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N092"), _
        LocalizableDescAtt("_D093"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property PauseLinkText() As LocalizableString
            Get
                If _PauseLinkText Is Nothing Then _PauseLinkText = New LocalizableString(LocalizableOpen._0395)
                Return _PauseLinkText
            End Get
            Set(ByVal value As LocalizableString)
                _PauseLinkText = value 'Formatage fait par gallerific
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N091"), _
        LocalizableDescAtt("_D092"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property PlayLinkText() As LocalizableString
            Get
                If _PlayLinkText Is Nothing Then _PlayLinkText = New LocalizableString(LocalizableOpen._0394)
                Return _PlayLinkText
            End Get
            Set(ByVal value As LocalizableString)
                _PlayLinkText = value 'Formatage fait par gallerific
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N087"), _
        LocalizableDescAtt("_D088"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property PrevLinkText() As LocalizableString
            Get
                If _PrevLinkText Is Nothing Then _PrevLinkText = New LocalizableString(LocalizableOpen._0396)
                Return _PrevLinkText
            End Get
            Set(ByVal value As LocalizableString)
                _PrevLinkText = value 'Formatage fait par gallerific
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N095"), _
        LocalizableDescAtt("_D096"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property RenderNavControls() As Boolean
            Get
                Return _RenderNavControls
            End Get
            Set(ByVal value As Boolean)
                _RenderNavControls = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N094"), _
        LocalizableDescAtt("_D095"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property RenderSSControls() As Boolean
            Get
                Return _RenderSSControls
            End Get
            Set(ByVal value As Boolean)
                _RenderSSControls = value
            End Set
        End Property

        <Browsable(False)> _
        Public Property ResizeAllPictures() As Boolean
            Get
                Return _ResizeAllPictures
            End Get
            Set(ByVal value As Boolean)
                _ResizeAllPictures = value
            End Set
        End Property

        <Browsable(False)> _
        Private Property ElemSize() As ElementSize
            Get
                'If _ElemSize Is Nothing Then
                '    ResizeAllPictures = True
                '    _ElemSize = CalculateSizesElement()
                '    If ResizeElem() Then Tools.WebElem.RefreshStylesElement(Me)
                'End If

                Return _ElemSize
            End Get
            Set(ByVal value As ElementSize)
                _ElemSize = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As CtlEditListOf.AddButton, ByVal selectedNodeTag As CtlEditListOf.NodeTag) As List(Of Object)
            ResizeAllPictures = True

            Dim newObs As New List(Of Object)

            If addButton.Name = "AddImage" Then

                Dim openFileDialog As New OpenFileDialog
                openFileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments
                openFileDialog.Filter = Various.GetListExtensionFileDialog(Enu.FilesMapType.Image)
                openFileDialog.RestoreDirectory = True
                openFileDialog.Multiselect = True

                If openFileDialog.ShowDialog = DialogResult.OK Then

                    Dim fileNames As String() = openFileDialog.FileNames
                    If Frm.GetFrmOptimizeImage.ImportFiles(openFileDialog.FileNames) Then
                        If Frm.GetFrmOptimizeImage.ShowDialog() = DialogResult.OK Then
                            fileNames = Frm.GetFrmOptimizeImage.ImagesFile
                        End If
                    End If

                    Dim actionArg As New Wait.ActionArg(Of String(), List(Of Object))(fileNames, newObs)
                    Frm.Wait.RunAction(New ActionWait(AddressOf AddImage), _
                                             actionArg, _
                                             LocalizableFormAndConverter._0128)

                End If

            End If

            Return newObs
        End Function

        Protected Overrides Function OnFrmEditListOfGetFormConfig() As CtlEditListOf.EditConfig
            Dim addButtonList As New List(Of CtlEditListOf.AddButton)
            addButtonList.Add(New CtlEditListOf.AddButton("AddImage", LocalizableFormAndConverter._0203, Nothing))
            Dim editConfig As New CtlEditListOf.EditConfig(LocalizableFormAndConverter._0113, LocalizableFormAndConverter._0170, addButtonList)
            Return editConfig
        End Function

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0113
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupMedia"
            info.ToolBoxIco = My.Resources.WEGallery1
            info.ToolBoxDescription = LocalizableOpen._0114
            info.AutoOpenProperty = "ConfigImages"
            info.SortPropertyList.Add(New SortProperty("ConfigImages", "Tools.png", LocalizableOpen._0030))
            Return info
        End Function

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(EnuScriptType.Css, "ElementsLibrary\Common\Css\WEGallery1.css", "WEFiles/Css/WEGallery1.css")
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEGallery1.js", "WEFiles/Client/WEGallery1.js")
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\jQuery\jquery.galleriffic.js", "WEFiles/Client/jquery.galleriffic.js")
            MyBase.OnInitExternalFiles()
        End Sub

        Protected Overrides Sub OnLoadStyleZones(ByRef configStylesZones As ConfigStylesZone)
            Select Case configStylesZones.Name
                Case "Thumb", "Zoom", "Navigation-container"
                    configStylesZones.Level = StylesZone.EnuLevel.Advenced
                    configStylesZones.GlobalEvent = True
            End Select
            MyBase.OnLoadStyleZones(configStylesZones)
        End Sub

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("Title", LocalizableOpen._0159, LocalizableOpen._0160))
            configStylesZones.Add(New ConfigStylesZone("Description", LocalizableOpen._0161, LocalizableOpen._0162))
            configStylesZones.Add(New ConfigStylesZone("PageIndex", LocalizableOpen._0163, LocalizableOpen._0164))
            configStylesZones.Add(New ConfigStylesZone("ImageFrame", LocalizableOpen._0165, LocalizableOpen._0166))
            configStylesZones.Add(New ConfigStylesZone("SelectedFrame", LocalizableOpen._0167, LocalizableOpen._0168))
            configStylesZones.Add(New ConfigStylesZone("ControlsPlayer", LocalizableOpen._0169, LocalizableOpen._0170))
            configStylesZones.Add(New ConfigStylesZone("NextPage", LocalizableOpen._0171, LocalizableOpen._0172))
            configStylesZones.Add(New ConfigStylesZone("PreviousPage", LocalizableOpen._0173, LocalizableOpen._0174))
            configStylesZones.Add(New ConfigStylesZone("BtnPlay", LocalizableOpen._0175, LocalizableOpen._0176))
            configStylesZones.Add(New ConfigStylesZone("BtnPause", LocalizableOpen._0177, LocalizableOpen._0178))
            configStylesZones.Add(New ConfigStylesZone("BtnNext", LocalizableOpen._0179, LocalizableOpen._0180))
            configStylesZones.Add(New ConfigStylesZone("BtnPrev", LocalizableOpen._0181, LocalizableOpen._0182))

            configStylesZones.Add(New ConfigStylesZone("Thumb", LocalizableOpen._0183, LocalizableOpen._0184))
            configStylesZones.Add(New ConfigStylesZone("Zoom", LocalizableOpen._0185, LocalizableOpen._0186))
            configStylesZones.Add(New ConfigStylesZone("Navigation-container", LocalizableOpen._0187, LocalizableOpen._0188))

            MyBase.OnOpen(configStylesZones)
        End Sub

        ''' <summary>
        ''' resizing of images before the saving and the preview
        ''' </summary>
        ''' <param name="mode"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnPageBeforeRender(ByVal mode As openElement.WebElement.Page.EnuTypeRenderMode)
            If Not mode = openElement.WebElement.Page.EnuTypeRenderMode.Editor AndAlso Me.Page.Culture = "DEFAULT" Then
                If ElemSize Is Nothing Then
                    ElemSize = CalculateSizesElement()
                    Call ResizeElem()
                End If
                Call ResizeImg()
            End If
            MyBase.OnPageBeforeRender(mode)
        End Sub

        Protected Overrides Sub OnPageSave()
            'only if we must to do it
            Call ResizeImg()

            MyBase.OnSave()
        End Sub

        'Private Sub AddFolderImage(ByVal actionArg As Wait.ActionArg(Of IO.FileInfo(), List(Of Object)))
        '    Dim fileNames As IO.FileInfo() = actionArg.Argument1
        '    Dim newObs As List(Of Object) = actionArg.Argument2
        '    For Each file As IO.FileInfo In fileNames
        '        If Tools.Various.GetFileType(file.Extension) <> Tools.Enu.FilesMapType.Image Then Continue For
        '        'traitement des images
        '        Dim image As New GalleryImages.GalleryImageInfo(Me, file.FullName, ConfigImages.GalleryForderLink, Me.Page.Culture)
        '        newObs.Add(image)
        '        Application.DoEvents()
        '    Next
        'End Sub
        Protected Overrides Sub OnResizeEnd()
            MyBase.OnResizeEnd()

            ResizeAllPictures = True
            ElemSize = CalculateSizesElement()
            Call ResizeElem()
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            If MyBase.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Editor Then
                Call RenderEditorMode(writer)
                MyBase.RenderEndTag(writer)
                Exit Sub
            End If

            writer.WriteBeginTag("div")
            writer.WriteAttribute("id", "container")
            writer.WriteAttribute("class", "container")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", String.Concat("navigation-container ", MyBase.GetStyleZoneClass("Navigation-container")))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.WriteBeginTag("div")
            writer.WriteAttribute("id", "thumbs")
            writer.WriteAttribute("class", "navigation")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.WriteBeginTag("a")
            writer.WriteAttribute("class", String.Concat("pageLink prev ", MyBase.GetStyleZoneClass("PreviousPage")))
            writer.WriteAttribute("style", "visibility: hidden;")
            writer.WriteAttribute("href", "#")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("a")
            writer.WriteLine()

            writer.WriteBeginTag("ul")
            writer.WriteAttribute("class", "thumbs noscript OESZ_thumbs")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            For Each image As GalleryImages.GalleryImageInfo In ConfigImages.Images
                Call LineRender(writer, image)
            Next

            writer.WriteEndTag("ul")
            writer.WriteLine()

            writer.WriteBeginTag("a")
            writer.WriteAttribute("class", String.Concat("pageLink next ", MyBase.GetStyleZoneClass("NextPage")))
            writer.WriteAttribute("style", "visibility: hidden;")
            writer.WriteAttribute("href", "#")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("a")
            writer.WriteLine()

            writer.WriteEndTag("div")
            writer.WriteLine()
            writer.WriteEndTag("div")
            writer.WriteLine()

            Call ContentRender(writer)

            writer.WriteBeginTag("div")
            writer.WriteAttribute("style", "clear: both;")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()
            writer.Indent -= 1
            writer.WriteEndTag("div")

            MyBase.RenderEndTag(writer)
        End Sub

        Private Sub AddImage(ByVal actionArg As Wait.ActionArg(Of String(), List(Of Object)))
            Dim fileNames As String() = actionArg.Argument1
            Dim newObs As List(Of Object) = actionArg.Argument2

            For Each fullFilePath As String In fileNames
                Dim image As New GalleryImages.GalleryImageInfo(Me, fullFilePath, ConfigImages.GalleryForderLink, Me.Page.Culture)
                newObs.Add(image)
                Application.DoEvents()
            Next
        End Sub

        Private Function CalculateSizesElement() As ElementSize
            Dim calElemSize As New ElementSize

            If MyBase.StylesSkin Is Nothing Then Return Nothing

            Dim elmWidth As Integer = MyBase.StylesSkin.BaseDiv.BaseStyles.GraphicWidth(True)
            Dim elmHeight As Integer = MyBase.StylesSkin.BaseDiv.BaseStyles.GraphicHeight(True)

            Dim nextPageWidth As Integer = MyBase.StylesSkin.FindStylesZone("NextPage").BaseStyles.GraphicWidth(True)
            If nextPageWidth = 0 Then nextPageWidth = 30

            Dim previousPageWidth As Integer = MyBase.StylesSkin.FindStylesZone("PreviousPage").BaseStyles.GraphicWidth(True)
            If previousPageWidth = 0 Then previousPageWidth = 30

            Dim thumbMarginLeft As Integer = MyBase.StylesSkin.FindStylesZone("Thumb").BaseStyles.Margin.Left(True).GetNumber()
            Dim thumbMarginRight As Integer = MyBase.StylesSkin.FindStylesZone("Thumb").BaseStyles.Margin.Right(True).GetNumber()
            Dim thumbMarginTop As Integer = MyBase.StylesSkin.FindStylesZone("Thumb").BaseStyles.Margin.Top(True).GetNumber()
            Dim thumbMarginBottom As Integer = MyBase.StylesSkin.FindStylesZone("Thumb").BaseStyles.Margin.Bottom(True).GetNumber()

            If thumbMarginLeft = 0 Then thumbMarginLeft = 1
            If thumbMarginRight = 0 Then thumbMarginRight = 1
            If thumbMarginTop = 0 Then thumbMarginTop = 1
            If thumbMarginBottom = 0 Then thumbMarginBottom = 1

            Dim selectedFrameBorderLeft As Integer = MyBase.StylesSkin.FindStylesZone("SelectedFrame").BaseStyles.BorderLeft.Width(True).GetNumber
            Dim selectedFrameBorderRight As Integer = MyBase.StylesSkin.FindStylesZone("SelectedFrame").BaseStyles.BorderRight.Width(True).GetNumber
            Dim selectedFrameBorderTop As Integer = MyBase.StylesSkin.FindStylesZone("SelectedFrame").BaseStyles.BorderTop.Width(True).GetNumber
            Dim selectedFrameBorderBottom As Integer = MyBase.StylesSkin.FindStylesZone("SelectedFrame").BaseStyles.BorderBottom.Width(True).GetNumber

            If selectedFrameBorderLeft = 0 Then selectedFrameBorderLeft = 1
            If selectedFrameBorderRight = 0 Then selectedFrameBorderRight = 1
            If selectedFrameBorderTop = 0 Then selectedFrameBorderTop = 1
            If selectedFrameBorderBottom = 0 Then selectedFrameBorderBottom = 1

            'thumbnail calculation = element's width - next and prev page - img margin - select Frame border
            Dim withOther As Integer = nextPageWidth + previousPageWidth + (NumThumbs * (thumbMarginLeft + thumbMarginRight)) + selectedFrameBorderLeft + selectedFrameBorderRight
            If elmWidth <= withOther Then OEMsgBox(LocalizableFormAndConverter._0171, MsgBoxType.Err)
            Dim widthForThumb As Integer = elmWidth - withOther

            Dim thumWidth = Math.Round(widthForThumb / NumThumbs, 0)
            calElemSize.ThumbSize = New Size(thumWidth, thumWidth)

            'button next and prev calculation
            calElemSize.PreviousPageSize = New Size(previousPageWidth, calElemSize.ThumbSize.Height)
            calElemSize.NextPageSize = New Size(nextPageWidth, calElemSize.ThumbSize.Height)

            'height of the navigation ctrl
            calElemSize.ControlNavHeight = MyBase.StylesSkin.FindStylesZone("ControlsPlayer").BaseStyles.GraphicHeight(True)
            If calElemSize.ControlNavHeight = 0 Then calElemSize.ControlNavHeight = 20

            calElemSize.NavigateHeight = calElemSize.ThumbSize.Height + selectedFrameBorderTop + selectedFrameBorderBottom + thumbMarginTop + thumbMarginBottom

            'Zoom calculation
            Dim heightOther As Integer = calElemSize.ControlNavHeight + calElemSize.TextHeight + calElemSize.NavigateHeight
            If elmHeight < heightOther Then OEMsgBox(LocalizableFormAndConverter._0172, MsgBoxType.Err)
            Dim zoomHeight = elmHeight - heightOther
            calElemSize.ZoomSize = New Size(elmWidth, zoomHeight)

            Return calElemSize
        End Function

        ''' <summary>
        ''' gallery layout's Render 
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <remarks></remarks>
        Private Sub ContentRender(ByVal writer As HtmlWriter)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "content")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1

            'Image
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "slideshow-container")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1

            'next and prev button's image
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", String.Concat("controls ", "controls_" & Me.ID, " ", MyBase.GetStyleZoneClass("ControlsPlayer")))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "loader loading loading_" & Me.ID)
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "slideshow OESZ_ImageFrame slideshow_" & Me.ID)
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()

            writer.Indent -= 1
            writer.WriteEndTag("div")
            writer.WriteLine()

            writer.Indent -= 1
            writer.WriteEndTag("div")
            writer.WriteLine()

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "caption-container caption_" & Me.ID)
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.Indent += 1

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", String.Concat("photo-index ", MyBase.GetStyleZoneClass("PageIndex")))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            writer.Indent -= 1
            writer.WriteEndTag("div")
            writer.WriteLine()
        End Sub

        ''' <summary>
        ''' Images 
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <param name="image"></param>
        ''' <remarks></remarks>
        Private Sub LineRender(ByVal writer As HtmlWriter, ByVal image As GalleryImages.GalleryImageInfo)
            Dim imageLinkMini As Link
            Dim imageLink As Link

            imageLinkMini = image.LinkSize1
            imageLink = image.LinkSize2

            writer.WriteBeginTag("li")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1

            'Image
            writer.WriteBeginTag("a")
            writer.WriteAttribute("class", "thumb")
            writer.WriteAttribute("title", "")
            writer.WriteAttribute("href", MyBase.GetLink(imageLink))
            writer.Write(HtmlTextWriter.TagRightChar)

            'Thumbnail
            writer.WriteBeginTag("img")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Thumb"))
            writer.WriteAttribute("src", MyBase.GetLink(imageLinkMini))
            writer.WriteAttribute("alt", "")
            writer.Write(HtmlTextWriter.SelfClosingTagEnd)
            writer.WriteEndTag("a")
            writer.WriteLine()

            'Caption
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "caption")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            'image-title
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "image-title")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1

            'Title + link
            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Title"))
            writer.Write(HtmlTextWriter.TagRightChar)

            If Not image.PageLink.IsEmpty Then
                writer.WriteBeginTag("a")
                writer.WriteHrefAttribute(Me, image.PageLink, True)
                writer.Write(HtmlTextWriter.TagRightChar)
            End If

            writer.Write(image.Title.GetValue(MyBase.Page.Culture))

            If Not image.PageLink.IsEmpty Then writer.WriteEndTag("a")

            writer.WriteEndTag("span")
            writer.WriteLine()

            'description
            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Description"))
            writer.Write(HtmlTextWriter.TagRightChar)
            Dim desc = image.Comment.GetValue(MyBase.Page.Culture)
            If Not String.IsNullOrEmpty(desc) Then writer.Write(" - ")
            writer.Write(desc)
            writer.WriteEndTag("span")
            writer.WriteLine()

            writer.Indent -= 1
            writer.WriteEndTag("div")
            writer.WriteLine()

            writer.WriteEndTag("div")
            writer.WriteLine()

            writer.Indent -= 1
            writer.WriteEndTag("li")
            writer.WriteLine()
        End Sub

        Private Sub RenderEditorMode(ByVal writer As HtmlWriter)
            'display if no file is selected in the editor
            writer.WriteBeginTag("table")
            writer.WriteAttribute("style", "width:100%;height:100%;background-color:#999999;")
            writer.Write(HtmlTextWriter.TagRightChar)

            writer.WriteFullBeginTag("tr")
            writer.WriteBeginTag("td")
            writer.WriteAttribute("style", "text-align:center;vertical-align:middle")
            writer.Write(HtmlTextWriter.TagRightChar)

            writer.WriteBeginTag("img")
            writer.WriteAttribute("src", Path.Combine(Utils.EditorModCSSPath, "images/Gallery.png"))
            writer.Write(HtmlTextWriter.SelfClosingTagEnd)
            writer.WriteBreak()

            writer.WriteBeginTag("span")
            writer.WriteAttribute("style", "color:#FFFFF;font-size :10px;font-family :Arial ;")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.Write(LocalizablePropertyDefaultValue._0013)
            writer.WriteEndTag("span")

            writer.WriteEndTag("td")
            writer.WriteEndTag("tr")
            writer.WriteEndTag("table")
        End Sub

        ''' <summary>
        ''' direct resize of the element's style zones  
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ResizeElem()
            If MyBase.StylesSkin.FindStylesZone("Thumb") Is Nothing Then Exit Sub
            MyBase.StylesSkin.FindStylesZone("Thumb").BaseStyles.Width.Value = ElemSize.ThumbSize.Width
            MyBase.StylesSkin.FindStylesZone("Thumb").BaseStyles.Height.Value = ElemSize.ThumbSize.Height
            MyBase.StylesSkin.FindStylesZone("NextPage").BaseStyles.Height.Value = ElemSize.NextPageSize.Height
            MyBase.StylesSkin.FindStylesZone("PreviousPage").BaseStyles.Height.Value = ElemSize.PreviousPageSize.Height
            MyBase.StylesSkin.FindStylesZone("Navigation-container").BaseStyles.Height.Value = ElemSize.NavigateHeight

            MyBase.StylesSkin.FindStylesZone("Zoom").BaseStyles.Height.Value = ElemSize.ZoomSize.Height
            MyBase.StylesSkin.FindStylesZone("Zoom").BaseStyles.Width.Value = ElemSize.ZoomSize.Width
            MyBase.StylesSkin.FindStylesZone("ImageFrame").BaseStyles.Height.Value = ElemSize.ZoomSize.Height
        End Sub

        Private Sub ResizeImg()
            Dim resizeConfig1 As New Picture.PictureResizeConfig(ElemSize.ThumbSize, Enu.EnuPriorityImageResize.None, Me.JpgBackColor)
            Dim resizeConfig2 As New Picture.PictureResizeConfig(ElemSize.ZoomSize, Enu.EnuPriorityImageResize.None, Me.JpgBackColor)

            Me.ConfigImages.Resize(Me, resizeConfig1, resizeConfig2, Nothing, ResizeAllPictures)

            ResizeAllPictures = False
        End Sub

        #End Region 'Methods

        #Region "Nested Types"

        ''' <summary>
        ''' Config size class : size of the internal zones
        ''' </summary>
        ''' <remarks>Obligatory for the size calculation</remarks>
        <Serializable> _
        Private Class ElementSize

            #Region "Fields"

            Private _ControlNavHeight As Integer
            Private _NavigateHeight As Integer
            Private _NextPageSize As Size
            Private _PreviousPageSize As Size
            Private _TextHeight As Integer
            Private _ThumbSize As Size
            Private _ZoomSize As Size

            #End Region 'Fields

            #Region "Properties"

            Public Property ControlNavHeight() As Integer
                Get
                    Return _ControlNavHeight
                End Get
                Set(ByVal value As Integer)
                    _ControlNavHeight = value
                End Set
            End Property

            Public Property NavigateHeight() As Integer
                Get
                    Return _NavigateHeight
                End Get
                Set(ByVal value As Integer)
                    _NavigateHeight = value
                End Set
            End Property

            Public Property NextPageSize() As Size
                Get
                    Return _NextPageSize
                End Get
                Set(ByVal value As Size)
                    _NextPageSize = value
                End Set
            End Property

            Public Property PreviousPageSize() As Size
                Get
                    Return _PreviousPageSize
                End Get
                Set(ByVal value As Size)
                    _PreviousPageSize = value
                End Set
            End Property

            Public ReadOnly Property TextHeight() As Integer
                Get
                    If _TextHeight = 0 Then _TextHeight = 20
                    Return _TextHeight
                End Get
            End Property

            Public Property ThumbSize() As Size
                Get
                    Return _ThumbSize
                End Get
                Set(ByVal value As Size)
                    _ThumbSize = value
                End Set
            End Property

            Public Property ZoomSize() As Size
                Get
                    Return _ZoomSize
                End Get
                Set(ByVal value As Size)
                    _ZoomSize = value
                End Set
            End Property

            #End Region 'Properties

        End Class

        #End Region 'Nested Types

    End Class

End Namespace

