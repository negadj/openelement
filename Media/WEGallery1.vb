Imports System.Windows.Forms
Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports System.Drawing
Imports openElement.WebElement.DataType
Imports openElement.WebElement.Editors.Control.CtlEditListOf
Imports openElement

Namespace Elements.Media

    <Serializable()> _
    Public Class WEGallery1
        Inherits ElementBase

        <Common.Attributes.ContainsLinks()> _
        Private _ConfigImages As DataType.GalleryImages

        Private _Delay As Integer
        Private _NumThumbs As Integer
        Private _PlayLinkText As DataType.LocalizableString
        Private _PauseLinkText As DataType.LocalizableString
        Private _PrevLinkText As DataType.LocalizableString
        Private _NextLinkText As DataType.LocalizableString
        Private _RenderSSControls As Boolean
        Private _RenderNavControls As Boolean
        Private _AutoStart As Boolean
        Private _ElemSize As ElementSize
        Private _ResizeAllPictures As Boolean
        Private _JpgBackColor As Color

#Region "Obsolete"

        Private _Config As DataType.GalleryBlock

#End Region

#Region "Properties"
       
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N001"), _
        Ressource.localizable.LocalizableDescAtt("_D083"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeEditListOf), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property ConfigImages() As DataType.GalleryImages
            Get
                If _ConfigImages Is Nothing Then _ConfigImages = New DataType.GalleryImages
                Return _ConfigImages
            End Get
            Set(ByVal value As DataType.GalleryImages)
                _ConfigImages = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
       Ressource.localizable.LocalizableNameAtt("_N083"), _
       Ressource.localizable.LocalizableDescAtt("_D084"), _
       Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
       Public Property Delay() As Integer
            Get
                If _Delay = 0 Then _Delay = 2000
                Return _Delay
            End Get
            Set(ByVal value As Integer)
                _Delay = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
     Ressource.localizable.LocalizableNameAtt("_N084"), _
     Ressource.localizable.LocalizableDescAtt("_D085"), _
     Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
     Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
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
       Ressource.localizable.LocalizableNameAtt("_N091"), _
       Ressource.localizable.LocalizableDescAtt("_D092"), _
       TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
       Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
       Public Property PlayLinkText() As DataType.LocalizableString
            Get
                If _PlayLinkText Is Nothing Then _PlayLinkText = New DataType.LocalizableString(My.Resources.text.LocalizableOpen._0394)
                Return _PlayLinkText
            End Get
            Set(ByVal value As DataType.LocalizableString)
                _PlayLinkText = value 'Formatage fait par gallerific
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N092"), _
        Ressource.localizable.LocalizableDescAtt("_D093"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property PauseLinkText() As DataType.LocalizableString
            Get
                If _PauseLinkText Is Nothing Then _PauseLinkText = New DataType.LocalizableString(My.Resources.text.LocalizableOpen._0395)
                Return _PauseLinkText
            End Get
            Set(ByVal value As DataType.LocalizableString)
                _PauseLinkText = value 'Formatage fait par gallerific
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N087"), _
        Ressource.localizable.LocalizableDescAtt("_D088"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property PrevLinkText() As DataType.LocalizableString
            Get
                If _PrevLinkText Is Nothing Then _PrevLinkText = New DataType.LocalizableString(My.Resources.text.LocalizableOpen._0396)
                Return _PrevLinkText
            End Get
            Set(ByVal value As DataType.LocalizableString)
                _PrevLinkText = value 'Formatage fait par gallerific
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N086"), _
        Ressource.localizable.LocalizableDescAtt("_D087"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property NextLinkText() As DataType.LocalizableString
            Get
                If _NextLinkText Is Nothing Then _NextLinkText = New DataType.LocalizableString(My.Resources.text.LocalizableOpen._0397)
                Return _NextLinkText
            End Get
            Set(ByVal value As DataType.LocalizableString)
                _NextLinkText = value 'Formatage fait par gallerific
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N094"), _
        Ressource.localizable.LocalizableDescAtt("_D095"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property RenderSSControls() As Boolean
            Get
                Return _RenderSSControls
            End Get
            Set(ByVal value As Boolean)
                _RenderSSControls = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
         Ressource.localizable.LocalizableNameAtt("_N095"), _
         Ressource.localizable.LocalizableDescAtt("_D096"), _
         Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
         Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
         Public Property RenderNavControls() As Boolean
            Get
                Return _RenderNavControls
            End Get
            Set(ByVal value As Boolean)
                _RenderNavControls = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N090"), _
        Ressource.localizable.LocalizableDescAtt("_D091"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property AutoStart() As Boolean
            Get
                Return _AutoStart
            End Get
            Set(ByVal value As Boolean)
                _AutoStart = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
       Ressource.localizable.LocalizableNameAtt("_N136"), _
       Ressource.localizable.LocalizableDescAtt("_D136"), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
       Public Property JpgBackColor() As Color
            Get
                Return _JpgBackColor
            End Get
            Set(ByVal value As Color)
                _JpgBackColor = value
                ResizeAllPictures = True
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

        <Browsable(False)> _
        Public Property ResizeAllPictures() As Boolean
            Get
                Return _ResizeAllPictures
            End Get
            Set(ByVal value As Boolean)
                _ResizeAllPictures = value
            End Set
        End Property

#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEGallery1", page, parentID, templateName)
            RenderNavControls = True
            RenderSSControls = True

        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0113
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupMedia"
            info.ToolBoxIco = My.Resources.WEGallery1
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0114
            info.AutoOpenProperty = "ConfigImages"
            info.SortPropertyList.Add(New SortProperty("ConfigImages", "Tools.png", My.Resources.text.LocalizableOpen._0030))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Title", My.Resources.text.LocalizableOpen._0159, My.Resources.text.LocalizableOpen._0160))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Description", My.Resources.text.LocalizableOpen._0161, My.Resources.text.LocalizableOpen._0162))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("PageIndex", My.Resources.text.LocalizableOpen._0163, My.Resources.text.LocalizableOpen._0164))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("ImageFrame", My.Resources.text.LocalizableOpen._0165, My.Resources.text.LocalizableOpen._0166))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("SelectedFrame", My.Resources.text.LocalizableOpen._0167, My.Resources.text.LocalizableOpen._0168))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("ControlsPlayer", My.Resources.text.LocalizableOpen._0169, My.Resources.text.LocalizableOpen._0170))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("NextPage", My.Resources.text.LocalizableOpen._0171, My.Resources.text.LocalizableOpen._0172))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("PreviousPage", My.Resources.text.LocalizableOpen._0173, My.Resources.text.LocalizableOpen._0174))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("BtnPlay", My.Resources.text.LocalizableOpen._0175, My.Resources.text.LocalizableOpen._0176))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("BtnPause", My.Resources.text.LocalizableOpen._0177, My.Resources.text.LocalizableOpen._0178))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("BtnNext", My.Resources.text.LocalizableOpen._0179, My.Resources.text.LocalizableOpen._0180))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("BtnPrev", My.Resources.text.LocalizableOpen._0181, My.Resources.text.LocalizableOpen._0182))

            configStylesZones.Add(New StylesManager.ConfigStylesZone("Thumb", My.Resources.text.LocalizableOpen._0183, My.Resources.text.LocalizableOpen._0184))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Zoom", My.Resources.text.LocalizableOpen._0185, My.Resources.text.LocalizableOpen._0186))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Navigation-container", My.Resources.text.LocalizableOpen._0187, My.Resources.text.LocalizableOpen._0188))

            MyBase.OnOpen(configStylesZones)

        End Sub

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(Common.EnuScriptType.Css, "ElementsLibrary\Common\Css\WEGallery1.css", "WEFiles/Css/WEGallery1.css")
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEGallery1.js", "WEFiles/Client/WEGallery1.js")
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\jQuery\jquery.galleriffic.js", "WEFiles/Client/jquery.galleriffic.js")
            MyBase.OnInitExternalFiles()
        End Sub

        Protected Overrides Sub OnLoadStyleZones(ByRef configStylesZones As openElement.WebElement.StylesManager.ConfigStylesZone)
            Select Case configStylesZones.Name
                Case "Thumb", "Zoom", "Navigation-container"
                    configStylesZones.Level = StylesManager.StylesZone.EnuLevel.Advenced
                    configStylesZones.GlobalEvent = True
            End Select
            MyBase.OnLoadStyleZones(configStylesZones)
        End Sub

#End Region

        Protected Overrides Function OnFrmEditListOfGetFormConfig() As openElement.WebElement.Editors.Control.CtlEditListOf.EditConfig
            Dim addButtonList As New List(Of AddButton)
            addButtonList.Add(New AddButton("AddImage", My.Resources.text.LocalizableFormAndConverter._0203, Nothing))
            Dim editConfig As New EditConfig(My.Resources.text.LocalizableFormAndConverter._0113, My.Resources.text.LocalizableFormAndConverter._0170, addButtonList)
            Return editConfig
        End Function

        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As AddButton, ByVal selectedNodeTag As NodeTag) As List(Of Object)
            ResizeAllPictures = True

            Dim newObs As New List(Of Object)

            If addButton.Name = "AddImage" Then

                Dim openFileDialog As New OpenFileDialog
                openFileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments
                openFileDialog.Filter = Tools.Various.GetListExtensionFileDialog(Tools.Enu.FilesMapType.Image)
                openFileDialog.RestoreDirectory = True
                openFileDialog.Multiselect = True

                If openFileDialog.ShowDialog = DialogResult.OK Then

                    Dim fileNames As String() = openFileDialog.FileNames
                    If Tools.Frm.GetFrmOptimizeImage.ImportFiles(openFileDialog.FileNames) Then
                        If Tools.Frm.GetFrmOptimizeImage.ShowDialog() = DialogResult.OK Then
                            fileNames = Tools.Frm.GetFrmOptimizeImage.ImagesFile
                        End If
                    End If

                    Dim actionArg As New Wait.ActionArg(Of String(), List(Of Object))(fileNames, newObs)
                    Tools.Frm.Wait.RunAction(New ActionWait(AddressOf AddImage), _
                                             actionArg, _
                                             My.Resources.text.LocalizableFormAndConverter._0128)

                End If

            End If

            Return newObs

        End Function


        Private Sub AddImage(ByVal actionArg As Wait.ActionArg(Of String(), List(Of Object)))
            Dim fileNames As String() = actionArg.Argument1
            Dim newObs As List(Of Object) = actionArg.Argument2

            For Each fullFilePath As String In fileNames
                Dim image As New GalleryImages.GalleryImageInfo(Me, fullFilePath, ConfigImages.GalleryForderLink, Me.Page.Culture)
                newObs.Add(image)
                Application.DoEvents()
            Next
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

        Private Sub ResizeImg()

            Dim resizeConfig1 As New openElement.Tools.Picture.PictureResizeConfig(ElemSize.ThumbSize, openElement.Tools.Enu.EnuPriorityImageResize.None, Me.JpgBackColor)
            Dim resizeConfig2 As New openElement.Tools.Picture.PictureResizeConfig(ElemSize.ZoomSize, openElement.Tools.Enu.EnuPriorityImageResize.None, Me.JpgBackColor)

            Me.ConfigImages.Resize(Me, resizeConfig1, resizeConfig2, Nothing, ResizeAllPictures)

            ResizeAllPictures = False
        End Sub

        ''' <summary>
        ''' resizing of images before the saving and the preview
        ''' </summary>
        ''' <param name="mode"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnPageBeforeRender(ByVal mode As Page.EnuTypeRenderMode)
            If Not mode = Page.EnuTypeRenderMode.Editor AndAlso Me.Page.Culture = "DEFAULT" Then
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
            If elmWidth <= withOther Then OEMsgBox(My.Resources.text.LocalizableFormAndConverter._0171, MsgBoxType.Err)
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
            If elmHeight < heightOther Then OEMsgBox(My.Resources.text.LocalizableFormAndConverter._0172, MsgBoxType.Err)
            Dim zoomHeight = elmHeight - heightOther
            calElemSize.ZoomSize = New Size(elmWidth, zoomHeight)

            Return calElemSize
        End Function

        ''' <summary>
        ''' direct resize of the element's style zones  
        ''' </summary>
        ''' <remarks></remarks>
        Private Function ResizeElem() As Boolean

            If MyBase.StylesSkin.FindStylesZone("Thumb") Is Nothing Then Exit Function
            MyBase.StylesSkin.FindStylesZone("Thumb").BaseStyles.Width.Value = ElemSize.ThumbSize.Width
            MyBase.StylesSkin.FindStylesZone("Thumb").BaseStyles.Height.Value = ElemSize.ThumbSize.Height
            MyBase.StylesSkin.FindStylesZone("NextPage").BaseStyles.Height.Value = ElemSize.NextPageSize.Height
            MyBase.StylesSkin.FindStylesZone("PreviousPage").BaseStyles.Height.Value = ElemSize.PreviousPageSize.Height
            MyBase.StylesSkin.FindStylesZone("Navigation-container").BaseStyles.Height.Value = ElemSize.NavigateHeight

            MyBase.StylesSkin.FindStylesZone("Zoom").BaseStyles.Height.Value = ElemSize.ZoomSize.Height
            MyBase.StylesSkin.FindStylesZone("Zoom").BaseStyles.Width.Value = ElemSize.ZoomSize.Width
            MyBase.StylesSkin.FindStylesZone("ImageFrame").BaseStyles.Height.Value = ElemSize.ZoomSize.Height


            Return True
        End Function

#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)

            If MyBase.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Editor Then
                Call RenderEditorMode(writer)
                MyBase.RenderEndTag(writer)
                Exit Sub
            End If

            writer.WriteBeginTag("div")
            writer.WriteAttribute("id", "container")
            writer.WriteAttribute("class", "container")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", String.Concat("navigation-container ", MyBase.GetStyleZoneClass("Navigation-container")))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.WriteBeginTag("div")
            writer.WriteAttribute("id", "thumbs")
            writer.WriteAttribute("class", "navigation")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.WriteBeginTag("a")
            writer.WriteAttribute("class", String.Concat("pageLink prev ", MyBase.GetStyleZoneClass("PreviousPage")))
            writer.WriteAttribute("style", "visibility: hidden;")
            writer.WriteAttribute("href", "#")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("a")
            writer.WriteLine()

            writer.WriteBeginTag("ul")
            writer.WriteAttribute("class", "thumbs noscript OESZ_thumbs")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
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
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("a")
            writer.WriteLine()

            writer.WriteEndTag("div")
            writer.WriteLine()
            writer.WriteEndTag("div")
            writer.WriteLine()

            Call ContentRender(writer)

            writer.WriteBeginTag("div")
            writer.WriteAttribute("style", "clear: both;")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()
            writer.Indent -= 1
            writer.WriteEndTag("div")

            MyBase.RenderEndTag(writer)
        End Sub

        ''' <summary>
        ''' Images 
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <param name="image"></param>
        ''' <remarks></remarks>
        Private Sub LineRender(ByVal writer As Common.HtmlWriter, ByVal image As GalleryImages.GalleryImageInfo)
            Dim imageLinkMini As LinksManager.Link
            Dim imageLink As LinksManager.Link

            imageLinkMini = image.LinkSize1
            imageLink = image.LinkSize2

            writer.WriteBeginTag("li")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1

            'Image
            writer.WriteBeginTag("a")
            writer.WriteAttribute("class", "thumb")
            writer.WriteAttribute("title", "")
            writer.WriteAttribute("href", MyBase.GetLink(imageLink))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

            'Thumbnail
            writer.WriteBeginTag("img")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Thumb"))
            writer.WriteAttribute("src", MyBase.GetLink(imageLinkMini))
            writer.WriteAttribute("alt", "")
            writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)
            writer.WriteEndTag("a")
            writer.WriteLine()

            'Caption
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "caption")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            'image-title
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "image-title")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1

            'Title + link
            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Title"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

            If Not image.PageLink.IsEmpty Then
                writer.WriteBeginTag("a")
                writer.WriteHrefAttribute(Me, image.PageLink, True)
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            End If

            writer.Write(image.Title.GetValue(MyBase.Page.Culture))

            If Not image.PageLink.IsEmpty Then writer.WriteEndTag("a")

            writer.WriteEndTag("span")
            writer.WriteLine()

            'description
            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Description"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
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

        ''' <summary>
        ''' gallery layout's Render 
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <remarks></remarks>
        Private Sub ContentRender(ByVal writer As Common.HtmlWriter)

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "content")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1

            'Image
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "slideshow-container")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1

            'next and prev button's image  
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", String.Concat("controls ", "controls_" & Me.ID, " ", MyBase.GetStyleZoneClass("ControlsPlayer")))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()


            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "loader loading loading_" & Me.ID)
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "slideshow OESZ_ImageFrame slideshow_" & Me.ID)
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
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
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.Indent += 1

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", String.Concat("photo-index ", MyBase.GetStyleZoneClass("PageIndex")))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")

            writer.Indent -= 1
            writer.WriteEndTag("div")
            writer.WriteLine()
        End Sub

        Private Sub RenderEditorMode(ByVal writer As Common.HtmlWriter)

            'display if no file is selected in the editor
            writer.WriteBeginTag("table")
            writer.WriteAttribute("style", "width:100%;height:100%;background-color:#999999;")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

            writer.WriteFullBeginTag("tr")
            writer.WriteBeginTag("td")
            writer.WriteAttribute("style", "text-align:center;vertical-align:middle")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

            writer.WriteBeginTag("img")
            writer.WriteAttribute("src", IO.Path.Combine(Utils.EditorModCSSPath, "images/Gallery.png"))
            writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)
            writer.WriteBreak()

            writer.WriteBeginTag("span")
            writer.WriteAttribute("style", "color:#FFFFF;font-size :10px;font-family :Arial ;")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.Write(My.Resources.text.LocalizablePropertyDefaultValue._0013)
            writer.WriteEndTag("span")

            writer.WriteEndTag("td")
            writer.WriteEndTag("tr")
            writer.WriteEndTag("table")
        End Sub
#End Region

        ''' <summary>
        ''' Config size class : size of the internal zones
        ''' </summary>
        ''' <remarks>Obligatory for the size calculation</remarks>
        <Serializable()> _
        Private Class ElementSize
            Private _ThumbSize As Size
            Private _ControlNavHeight As Integer
            Private _NavigateHeight As Integer
            Private _TextHeight As Integer
            Private _ZoomSize As Size
            Private _NextPageSize As Size
            Private _PreviousPageSize As Size

            Public Property ThumbSize() As Size
                Get
                    Return _ThumbSize
                End Get
                Set(ByVal value As Size)
                    _ThumbSize = value
                End Set
            End Property

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

            Public Property TextHeight() As Integer
                Get
                    If _TextHeight = 0 Then _TextHeight = 20
                    Return _TextHeight
                End Get
                Set(ByVal value As Integer)
                    _TextHeight = value
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

            Public Property PreviousPageSize() As Size
                Get
                    Return _PreviousPageSize
                End Get
                Set(ByVal value As Size)
                    _PreviousPageSize = value
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

        End Class


    End Class

End Namespace
