Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Web.UI
Imports System.Windows.Forms

Imports openElement
Imports openElement.Tools
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.DataType.Enum
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Control
Imports openElement.WebElement.Editors.Converter.Enum
Imports openElement.WebElement.Elements
Imports openElement.WebElement.LinksManager
Imports openElement.WebElement.StylesManager
Imports openElement.WebElement.StylesManager.CssItems

Imports WebElement.Elements.Media.Editors.Converter
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Imports Page = openElement.WebElement.Page

Namespace Elements.Media

    ''' <summary>
    ''' VERTICAL Carrousel 
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable> _
    Public Class WEGalleryCarrousel2
        Inherits ElementBase

        #Region "Fields"

        Private _Auto As Boolean
        Private _AutoWaitingTime As Integer
        Private _BadProportionImg As Boolean = False
        <NonSerialized> _
        Private _CssUpdate As Boolean
        Private _Decalage As Integer

        ''' <summary>
        ''' height of div containing carrousel's images 
        ''' </summary>
        ''' <remarks></remarks>
        <NonSerialized> _
        Private _DivImageHeight2 As Integer

        ''' <summary>
        ''' width of div containing carrousel's images 
        ''' </summary>
        ''' <remarks></remarks>
        <NonSerialized> _
        Private _DivImageWidth2 As Integer

        ''' <summary>
        ''' slowing effect  
        ''' </summary>
        ''' <remarks></remarks>
        Private _Easing As EnumEasingEffect

        ''' <summary>
        ''' Config class write in the js file
        ''' </summary>
        ''' <remarks></remarks>
        Private _ImagesInfo As List(Of ImagesInfos)
        <ContainsLinks> _
        Private _ImagesList As GalleryImages

        ''' <summary>
        ''' display image's number at the first page load
        ''' </summary>
        ''' <remarks></remarks>
        Private _NbImage As Integer

        ''' <summary>
        ''' true if all images must be resized
        ''' </summary>
        ''' <remarks></remarks>
        <NonSerialized> _
        Private _ResizeAllPictures As Boolean
        Private _Sens As EnuCarrouselVerticalDirection
        Private _TypeEffect As EnuCarrouselTypeEffect
        Private _Vitesse As Integer

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEGalleryCarrousel2", page, parentID, templateName)
            MyBase.NumUpdate = 1
            'default value
            Me.Sens = EnuCarrouselVerticalDirection.GoToBottom
            Me.Vitesse = 1000
            Me._ResizeAllPictures = True
            Me.AutoWaitingTime = 1000
            Me.Easing = EnumEasingEffect.none
            DivImageHeight = 500
            DivImageWidth = 150
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
        Ressource.localizable.LocalizableNameAtt("_N120"), _
        LocalizableDescAtt("_D120"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Auto() As Boolean
            Get
                Return _auto
            End Get
            Set(ByVal value As Boolean)
                _auto = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
        Ressource.localizable.LocalizableNameAtt("_N119"), _
        LocalizableDescAtt("_D119"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property AutoWaitingTime() As Integer
            Get
                Return _autoWaitingTime
            End Get
            Set(ByVal value As Integer)
                _autoWaitingTime = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
        Ressource.localizable.LocalizableNameAtt("_N118"), _
        LocalizableDescAtt("_D118"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Decalage() As Integer
            Get
                If _decalage <= 0 Then _decalage = 1
                Return _decalage
            End Get
            Set(ByVal value As Integer)
                _decalage = value
            End Set
        End Property

        ''' <summary>
        ''' height of div containing carrousel's images (pixel)
        ''' </summary>
        ''' <remarks></remarks>
        <Browsable(False)> _
        Public Property DivImageHeight() As Integer
            Set(ByVal value As Integer)
                _DivImageHeight2 = value
            End Set
            Get
                If _DivImageHeight2 = 0 Then Call Me.Calculate_DivImageHeight()
                Return _DivImageHeight2
            End Get
        End Property

        ''' <summary>
        ''' width of div containing carrousel's images (pixel)
        ''' </summary>
        ''' <remarks></remarks>
        <Browsable(False)> _
        Public Property DivImageWidth() As Integer
            Set(ByVal value As Integer)
                _DivImageWidth2 = value
            End Set
            Get
                If _DivImageWidth2 = 0 Then Call Me.Calculate_ImagesWidth(MyBase.StylesSkin.FindStylesZone("Images"), GetModelZoneImageSafe())
                Return _DivImageWidth2
            End Get
        End Property

        ''' <summary>
        ''' Visual effect
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N232"), _
        LocalizableDescAtt("_D232"), _
        TypeConverter(GetType(TConvEnumEasingEffect)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Easing() As EnumEasingEffect
            Get
                Return _Easing
            End Get
            Set(ByVal value As EnumEasingEffect)
                _Easing = value
            End Set
        End Property

        ''' <summary>
        ''' export the visual effect in js file
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property EasingJs() As String
            Get
                Return _Easing.ToString
            End Get
        End Property

        ''' <summary>
        ''' Write in js file : contains the images's source path and the margins to apply 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property ImagesInfo() As List(Of ImagesInfos)
            Get
                If _ImagesInfo Is Nothing Then _ImagesInfo = New List(Of ImagesInfos)
                Return _ImagesInfo
            End Get
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N116"), _
        LocalizableDescAtt("_D116"), _
        Editor(GetType(UITypeEditListOf), GetType(UITypeEditor)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.ElementWithCss)> _
        Public Property ImagesList() As GalleryImages
            Get
                If _ImagesList Is Nothing Then
                    _ImagesList = New GalleryImages()
                End If
                Return _ImagesList
            End Get
            Set(ByVal value As GalleryImages)
                _ImagesList = value

                'we must recalculate the sizes of images
                Me.CalculateDimImages()

                If _BadProportionImg Then
                    OEMsgBox(LocalizableFormAndConverter._0200, MsgBoxType.Info, LocalizableFormAndConverter._0201)
                End If
                _BadProportionImg = False

            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
        Ressource.localizable.LocalizableNameAtt("_N117"), _
        LocalizableDescAtt("_D117"), _
        TypeConverter(GetType(TConvEnuCarrousel_VerticalDirection)), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Sens() As EnuCarrouselVerticalDirection
            Get
                Return _Sens
            End Get
            Set(ByVal value As EnuCarrouselVerticalDirection)
                _Sens = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
        Ressource.localizable.LocalizableNameAtt("_N138"), _
        LocalizableDescAtt("_D138"), _
        TypeConverter(GetType(TConvEnuCarrouselTypeEffect)), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property TypeEffect() As EnuCarrouselTypeEffect
            Get
                Return _TypeEffect
            End Get
            Set(ByVal value As EnuCarrouselTypeEffect)
                _TypeEffect = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
        Ressource.localizable.LocalizableNameAtt("_N121"), _
        LocalizableDescAtt("_D121"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Vitesse() As Integer
            Get
                Return _vitesse
            End Get
            Set(ByVal value As Integer)
                _vitesse = value
            End Set
        End Property

        ''' <summary>
        '''  true if the css has been update there  we must  recalculate the images's dimensions
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Property CssUpdate() As Boolean
            Get
                Return _CssUpdate
            End Get
            Set(ByVal value As Boolean)
                _CssUpdate = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Friend Shared Function GetModelStyleZoneSafe(ByVal styleSkin As StylesSkin, Optional ByVal name As String = "Images") As StylesZone
            If styleSkin Is Nothing Then Return Nothing
            Dim styleSkinModel As StylesSkinModel = styleSkin.StylesSkinModel : If styleSkinModel Is Nothing Then Return Nothing ' skin coming from model

            Dim r As StylesZone = styleSkinModel.FindStylesZone(name)
            If r Is Nothing Then r = styleSkin.FindStylesZone(name) ' if zone is missing from model, take it from element's skin
            Return r
        End Function

        ''' <summary>
        ''' After the css update, shows if the recalculation of carrousel's images is necessary
        ''' </summary>
        ''' <param name="zoneName"></param>
        ''' <param name="styleState"></param>
        ''' <param name="styleName"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnCssAfterUpdate(ByVal zoneName As String, ByVal styleState As StylesZone.EnuStyleState, ByVal styleName As CssBase.EnuStyleName)
            If zoneName = "Images" Then
                CssUpdate = True
            End If
            If zoneName = "BaseDiv" Then
                If styleName = CssBase.EnuStyleName.Border _
                    Or styleName = CssBase.EnuStyleName.Margin _
                    Or styleName = CssBase.EnuStyleName.Padding _
                    Or styleName = CssBase.EnuStyleName.Border _
                    Or styleName = CssBase.EnuStyleName.BorderTop _
                    Or styleName = CssBase.EnuStyleName.BorderLeft _
                    Or styleName = CssBase.EnuStyleName.BorderRight _
                    Or styleName = CssBase.EnuStyleName.BorderBottom Then
                    CssUpdate = True
                End If
            End If
            MyBase.OnCssAfterUpdate(zoneName, styleState, styleName)
        End Sub

        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As CtlEditListOf.AddButton, ByVal selectedNodeTag As CtlEditListOf.NodeTag) As List(Of Object)
            Dim newObs As New List(Of Object)

            'Add just an image
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

                    Frm.Wait.RunAction(New ActionWait(AddressOf AddImage), _
                                         New Wait.ActionArg(Of String(), List(Of Object))(fileNames, newObs), _
                                         LocalizableFormAndConverter._0128)

                End If

            End If

            ''Add a folder
            'Dim simpleFolderDialog As New openElement.Forms.FrmSimpleFolderDialog(openElement.Forms.FrmSimpleFolderDialog.EnuTypeFirstButton.MyPictures, False)

            'If simpleFolderDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            '    Dim folderInfo As New IO.DirectoryInfo(simpleFolderDialog.SelectedFolderPath)

            '    Tools.Frm.Wait.RunAction(New ActionWait(AddressOf AddFolderImage), _
            '                             New Wait.ActionArg(Of IO.FileInfo(), List(Of Object))(folderInfo.GetFiles, NewObs), _
            '                             My.Resources.text.LocalizableFormAndConverter._0128)

            'End If
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
            info.ToolBoxCaption = LocalizableOpen._0312
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupMedia"
            info.ToolBoxIco = My.Resources.WECarrousel2
            info.ToolBoxDescription = LocalizableOpen._0313
            info.AutoOpenProperty = "ImagesList"
            info.SortPropertyList.Add(New SortProperty("ImagesList", "Tools.png", LocalizableOpen._0199))
            Return info
        End Function

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(EnuScriptType.Css, "ElementsLibrary\Common\Css\WEGalleryCarrousel2.css", "WEFiles/Css/WEGalleryCarrousel2.css")
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEGalleryCarrousel2.js", "WEFiles/Client/WEGalleryCarrousel2.js")
            MyBase.AddSharedScripts(EnuSharedScript.jQueryEasing)
            MyBase.OnInitExternalFiles()
        End Sub

        Protected Overrides Sub OnLoadStyleZones(ByRef configStylesZones As ConfigStylesZone)
            Select Case configStylesZones.Name
                Case "Images"
                    configStylesZones.UIDisabledRibbon.Add(StylesZone.EnuDisabledRibbonType.Margin)
            End Select
            MyBase.OnLoadStyleZones(configStylesZones)
        End Sub

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("Images", LocalizableOpen._0129, LocalizableOpen._0130))
            configStylesZones.Add(New ConfigStylesZone("Next", LocalizableOpen._0131, LocalizableOpen._0132))
            configStylesZones.Add(New ConfigStylesZone("Previous", LocalizableOpen._0133, LocalizableOpen._0134))

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub OnPageBeforeRender(ByVal mode As Page.EnuTypeRenderMode)
            ' we must recalculate the size if the css (border,margin,padding) has been modified

            If Me.Page.RenderMode = Page.EnuTypeRenderMode.Export AndAlso CssUpdate Then
                Me.DivImageHeight = 0 'Force the height calculation
                Me.DivImageWidth = 0 'Force the width calculation
                Call CalculateDimImages()
                CssUpdate = False
            End If

            MyBase.OnPageBeforeRender(mode)
        End Sub

        Protected Overrides Sub OnPageInit()
            If MyBase.NumUpdate = 0 Then
                'we must recalculate the sizes, the images number and the width of arround div
                _ResizeAllPictures = True
                For Each image As GalleryImages.GalleryImageInfo In ImagesList.Images
                    image.UpdateSize = True
                Next

                Me.DivImageHeight = 0 'force the height calculation
                Me.DivImageWidth = 0 'force the width calculation
                Call CalculateDimImages() ' calculate at saving and preview
                Call ResizeImage(DivImageHeight)
                MyBase.NumUpdate = 1
            End If
            MyBase.OnPageInit()
        End Sub

        ''' <summary>
        ''' events on the saving or cloning
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnPageSave()
            'we resize the images only we must do it
            Call ResizeImage(DivImageWidth)

            Call CalculateDimImages()  'very (VERY) essential

            MyBase.OnSave()
        End Sub

        Protected Overrides Sub OnResizeEnd()
            'force the resizing of images and margins
            _ResizeAllPictures = True
            For Each image As GalleryImages.GalleryImageInfo In ImagesList.Images
                image.UpdateSize = True
            Next

            'we must recalculation the height, images number and the div around width
            Me.DivImageWidth = 0 'force the Width calculation
            Me.DivImageHeight = 0 'force the height calculation
            Call CalculateDimImages()

            MyBase.OnResizeEnd()

            If _BadProportionImg Then
                OEMsgBox(LocalizableFormAndConverter._0200, MsgBoxType.Info, LocalizableFormAndConverter._0201) 'Certaines images n'étant pas proportionnel aux dimensions du carrousel, elles  seront  redimensionnées pour s'afficher correctement.
            End If
            _BadProportionImg = False
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            'Private Sub RenderExportMode(ByRef writer As Common.HtmlWriter)
            MyBase.RenderBeginTag(writer)

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Previous"))
            writer.WriteAttribute("style", "position:absolute")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "WECarrousel2Parent")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.Indent += 1
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "WECarrousel2ImagesParent")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1

            If MyBase.Page.RenderMode <> Page.EnuTypeRenderMode.Export Then

                writer.WriteBeginTag("table")
                writer.WriteAttribute("style", "width:100%;height:100%;background-color:#999999;")
                writer.Write(HtmlTextWriter.TagRightChar)

                writer.WriteFullBeginTag("tr")
                writer.WriteBeginTag("td")
                writer.WriteAttribute("style", "text-align:center;vertical-align:middle")
                writer.Write(HtmlTextWriter.TagRightChar)

                writer.WriteBeginTag("div")
                writer.WriteAttribute("style", "color:#FFFFF;font-size :10px;font-family :Arial;white-space:normal; word-wrap:false;")
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.Write(LocalizablePropertyDefaultValue._0015)
                writer.WriteEndTag("div")

                writer.WriteEndTag("td")
                writer.WriteEndTag("tr")
                writer.WriteEndTag("table")
            Else
                If _NbImage <> 0 Then
                    Dim totalImgH As Integer = 0
                    For i As Integer = 0 To _NbImage - 1
                        totalImgH += ImagesInfo(i).ImgOuterHeight
                    Next
                    Dim mt As Integer = (Me.DivImageHeight - totalImgH) / (Me._NbImage + 1)
                    If mt < 0 Then mt = 0 'if the image is too large

                    Dim oldPosition = 0
                    Dim oldheight = 0
                    Dim topPosition

                    For i As Integer = 0 To _NbImage - 1
                        topPosition = mt + oldPosition + oldheight
                        oldPosition = topPosition
                        oldheight = ImagesInfo(i).ImgOuterHeight

                        Dim pageLink As String = MyBase.GetLink(ImagesInfo(i).PageLink, Me.Page.Culture)
                        Dim imgPath As String = MyBase.GetLink(ImagesInfo(i).ImgURL, Me.Page.Culture)

                        If String.IsNullOrEmpty(imgPath) Then
                            imgPath = MyBase.GetLink(ImagesInfo(i).ImageOriginURL, Me.Page.Culture)
                        End If

                        writer.WriteBeginTag("div")
                        writer.WriteAttribute("class", "CarrouselV_Img")
                        writer.WriteAttribute("style", String.Concat("width:", ImagesInfo(i).ImgWidth.ToString, "px ; height:", ImagesInfo(i).ImgHeight.ToString, "px ; top:", topPosition.ToString, "px;"))
                        writer.Write(HtmlTextWriter.TagRightChar)
                        'image html code
                        If Not String.IsNullOrEmpty(pageLink) Then
                            writer.WriteBeginTag("a")
                            writer.WriteHrefAttribute(Me, ImagesInfo(i).PageLink, True)
                            writer.Write(HtmlTextWriter.TagRightChar)
                        End If

                        writer.WriteBeginTag("img")
                        '03/19 update > the description is used for the alt tag
                        Dim desc As String = ImagesList.Images(i).Comment.GetValue(MyBase.Page.Culture)
                        If desc.Length > 50 Then desc = desc.Remove(0, 50)
                        writer.WriteAttribute("alt", desc)

                        writer.WriteAttribute("src", imgPath)
                        writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Images"))
                        Dim title As String = ImagesInfo(i).Title.GetValue(MyBase.Page.Culture)
                        If Not String.IsNullOrEmpty(title) Then writer.WriteAttribute("title", title)

                        writer.Write(HtmlTextWriter.SelfClosingTagEnd) ' />

                        If Not String.IsNullOrEmpty(pageLink) Then writer.WriteEndTag("a")

                        writer.WriteEndTag("div")

                        writer.WriteLine()

                    Next
                End If
            End If
            writer.Indent -= 1
            writer.WriteEndTag("div")
            writer.WriteLine()
            writer.Indent -= 1
            writer.WriteEndTag("div")
            writer.WriteLine()

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Next"))
            writer.WriteAttribute("style", "position:absolute")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()

            MyBase.RenderEndTag(writer)
        End Sub

        Private Sub AddImage(ByVal actionArg As Wait.ActionArg(Of String(), List(Of Object)))
            Dim fileNames As String() = actionArg.Argument1
            Dim newObs As List(Of Object) = actionArg.Argument2

            For Each fullFilePath As String In fileNames
                Dim image As New GalleryImages.GalleryImageInfo(Me, fullFilePath, ImagesList.GalleryForderLink, Me.Page.Culture)
                newObs.Add(image)
                Application.DoEvents()
            Next
        End Sub

        ''' <summary>
        ''' calculation or recalculation the dimentions of the images of the carrousel according to its height or of style zone's parameters
        ''' Be carefull! this calculation is on the all carrousel's images
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CalculateDimImages()
            'Images style zone (BE CAREFULL! it's not the first div around of images)
            Dim imagesZone As StylesZone = MyBase.StylesSkin.FindStylesZone("Images")
            Dim modelSkinImagesZone As StylesZone = GetModelZoneImageSafe()
            Dim innerHeight As Integer = Me.OuterPbHeight(imagesZone, modelSkinImagesZone) 'must be used for the dimensions calculation  of the images
            Dim outerHeight As Integer = Me.OuterMarginHeight(imagesZone, modelSkinImagesZone)    'must be used for the numbers images calculation

            'calculation of width margin starting from this height > to imagesInfo
            'we use also the padding and the border of image
            Call SearchDimImage(innerHeight)

            'we must find the initial images number(initial first last last index find by js))
            Dim baseHeight As Integer = 0
            _NbImage = 0

            For Each image As ImagesInfos In Me.ImagesInfo
                baseHeight = baseHeight + (image.ImgOuterHeight + outerHeight)
                If baseHeight < Me.DivImageHeight Then _NbImage = _NbImage + 1 Else Exit For
            Next

            If Me.ImagesInfo.Count <> 0 AndAlso _NbImage = 0 Then
                'special case where the first image is greater of the carrousel's width
                _NbImage = 1
            End If
        End Sub

        ''' <summary>
        ''' search carousel's heigth
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Calculate_DivImageHeight()
            If Not String.IsNullOrEmpty(MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Value) _
                AndAlso IsNumeric(MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Value) Then
                DivImageHeight = Integer.Parse(MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Value)
                Exit Sub
            End If

            Dim modelSkin As StylesZone = GetModelZoneImageSafe()

            'Model's value
            If Not String.IsNullOrEmpty(modelSkin.BaseStyles.Height.Value) AndAlso IsNumeric(modelSkin.BaseStyles.Height.Value) Then DivImageHeight = Integer.Parse(modelSkin.BaseStyles.Height.Value)
        End Sub

        ''' <summary>
        ''' calculation of images's height and update the _imageheight property
        ''' </summary>
        ''' <param name="imagesZone"></param>
        ''' <remarks></remarks>
        Private Sub Calculate_ImagesWidth(ByVal imagesZone As StylesZone, ByVal modelStyleImageZone As StylesZone)
            'Special case where we are no image's height
            If Not String.IsNullOrEmpty(imagesZone.BaseStyles.Width.Value) AndAlso IsNumeric(imagesZone.BaseStyles.Width.Value) Then
                DivImageWidth = Integer.Parse(imagesZone.BaseStyles.Width.Value)
            Else
                Dim modelSkin As StylesZone = GetModelZoneImageSafe()
                Dim modelWidth As String = "" : If modelSkin IsNot Nothing Then modelWidth = modelSkin.BaseStyles.Width.Value
                If Not String.IsNullOrEmpty(modelWidth) AndAlso IsNumeric(modelWidth) Then DivImageWidth = Integer.Parse(modelWidth) : Exit Sub

                Dim baseDivWidthValue As String = MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value
                If Not String.IsNullOrEmpty(baseDivWidthValue) AndAlso IsNumeric(baseDivWidthValue) Then DivImageWidth = Integer.Parse(baseDivWidthValue)

                Dim outerWidth As Integer = Me.Outer_width(imagesZone, modelStyleImageZone, True)
                If outerWidth <> 0 Then DivImageWidth = DivImageWidth - outerWidth
            End If
        End Sub

        Private Function GetModelZoneImageSafe() As StylesZone
            Return GetModelStyleZoneSafe(MyBase.StylesSkin)
        End Function

        ''' <summary>
        ''' research for the style zone of the margin-top and margin-bottom
        ''' </summary>
        ''' <param name="styleZone"></param>
        ''' <returns></returns>
        ''' <remarks>no use the parent's div and ONLY MARGIN</remarks>
        Private Function OuterMarginHeight(ByVal styleZone As StylesZone, ByVal modelStyleZone As StylesZone) As Integer
            If styleZone Is Nothing OrElse modelStyleZone Is Nothing Then Return 0

            Dim outer As Integer = 0

            Dim marginTopValue As Integer = 0
            Dim marginBottomValue As Integer = 0

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Margin.Top.Value) Then Integer.TryParse(styleZone.BaseStyles.Margin.Top.Value, marginTopValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Margin.Top.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Margin.Top.Value, marginTopValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Margin.Bottom.Value) Then Integer.TryParse(styleZone.BaseStyles.Margin.Bottom.Value, marginBottomValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Margin.Bottom.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Margin.Bottom.Value, marginBottomValue)

            outer += marginBottomValue + marginTopValue
            Return outer
        End Function

        ''' <summary>
        ''' search the added dimension  (inside :padding and border)
        ''' </summary>
        ''' <param name="styleZone"></param>
        ''' <param name="modelStyleZone"></param>
        ''' <returns></returns>
        ''' <remarks>ONLY BORDER AND PADDING</remarks>
        Private Function OuterPbHeight(ByVal styleZone As StylesZone, ByVal modelStyleZone As StylesZone) As Integer
            If styleZone Is Nothing OrElse modelStyleZone Is Nothing Then Return 0

            Dim inner As Integer = 0

            Dim paddingTopValue As Integer = 0
            Dim paddingBottomValue As Integer = 0
            Dim borderValue As Integer = 0
            Dim borderTopValue As Integer = 0
            Dim borderBottomValue As Integer = 0

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Padding.Top.Value) Then Integer.TryParse(styleZone.BaseStyles.Padding.Top.Value, paddingTopValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Padding.Top.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Padding.Top.Value, paddingTopValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Padding.Bottom.Value) Then Integer.TryParse(styleZone.BaseStyles.Padding.Bottom.Value, paddingBottomValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Padding.Bottom.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Padding.Bottom.Value, paddingBottomValue)

            'special cas of border : used only if the style is known. (border-left and border-right on border priority)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Border.Width.Value) AndAlso styleZone.BaseStyles.Border.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.Border.Width.Value, borderValue) Else _
            If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Border.Width.Value) AndAlso modelStyleZone.BaseStyles.Border.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.Border.Width.Value, borderValue)

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.BorderTop.Width.Value) AndAlso styleZone.BaseStyles.BorderTop.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.BorderTop.Width.Value, borderTopValue) Else _
            If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.BorderTop.Width.Value) AndAlso modelStyleZone.BaseStyles.BorderTop.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.BorderTop.Width.Value, borderTopValue)

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.BorderBottom.Width.Value) AndAlso styleZone.BaseStyles.BorderBottom.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.BorderBottom.Width.Value, borderBottomValue) Else _
            If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.BorderBottom.Width.Value) AndAlso modelStyleZone.BaseStyles.BorderBottom.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.BorderBottom.Width.Value, borderBottomValue)

            If borderTopValue <> 0 Then inner += borderTopValue Else inner += borderValue
            If borderBottomValue <> 0 Then inner += borderBottomValue Else inner += borderValue

            inner += paddingBottomValue + paddingTopValue

            Return inner
        End Function

        ''' <summary>
        ''' search outer dimension for the styleZone  
        ''' </summary>
        ''' <param name="styleZone"></param>
        ''' <param name="withParent">true if we include the parent's padding</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function Outer_width(ByVal styleZone As StylesZone, ByVal modelStyleZone As StylesZone, ByVal withParent As Boolean) As Integer
            Dim outer As Integer = 0

            If withParent Then
                Dim baseStyles As Styles = MyBase.StylesSkin.BaseDiv.BaseStyles
                Dim modelBaseStyles As Styles = MyBase.StylesSkin.StylesSkinModel.BaseDiv.BaseStyles

                Dim parentPaddingLeftValue As Integer = 0
                Dim parentPaddingRightValue As Integer = 0
                Dim parentBorderValue As Integer = 0
                Dim parentBorderleftValue As Integer = 0
                Dim parentborderRightValue As Integer = 0

                'parent's PADDING
                If Not String.IsNullOrEmpty(baseStyles.Padding.Left.Value) Then Integer.TryParse(baseStyles.Padding.Left.Value, parentPaddingLeftValue) Else _
                    If Not String.IsNullOrEmpty(modelBaseStyles.Padding.Left.Value) Then Integer.TryParse(modelBaseStyles.Padding.Left.Value, parentPaddingLeftValue)
                If Not String.IsNullOrEmpty(baseStyles.Padding.Right.Value) Then Integer.TryParse(baseStyles.Padding.Right.Value, parentPaddingRightValue) Else _
                    If Not String.IsNullOrEmpty(modelBaseStyles.Padding.Right.Value) Then Integer.TryParse(modelBaseStyles.Padding.Right.Value, parentPaddingRightValue)
                'parent's BORDER
                If Not String.IsNullOrEmpty(baseStyles.Border.Width.Value) AndAlso baseStyles.Border.Style <> CssEnum.BorderStyle.novalue Then parentBorderValue = Integer.Parse(baseStyles.Border.Width.Value) Else _
                    If Not String.IsNullOrEmpty(modelBaseStyles.Border.Width.Value) AndAlso modelBaseStyles.Border.Style <> CssEnum.BorderStyle.novalue Then parentBorderValue = Integer.Parse(modelBaseStyles.Border.Width.Value)
                If Not String.IsNullOrEmpty(baseStyles.BorderLeft.Width.Value) AndAlso baseStyles.BorderLeft.Style <> CssEnum.BorderStyle.novalue Then parentBorderleftValue = Integer.Parse(baseStyles.BorderLeft.Width.Value) Else _
                    If Not String.IsNullOrEmpty(modelBaseStyles.BorderLeft.Width.Value) AndAlso modelBaseStyles.BorderLeft.Style <> CssEnum.BorderStyle.novalue Then parentBorderleftValue = Integer.Parse(modelBaseStyles.BorderLeft.Width.Value)
                If Not String.IsNullOrEmpty(baseStyles.BorderRight.Width.Value) AndAlso baseStyles.BorderRight.Style <> CssEnum.BorderStyle.novalue Then parentborderRightValue = Integer.Parse(baseStyles.BorderRight.Width.Value) Else _
                    If Not String.IsNullOrEmpty(modelBaseStyles.BorderRight.Width.Value) AndAlso modelBaseStyles.BorderRight.Style <> CssEnum.BorderStyle.novalue Then parentborderRightValue = Integer.Parse(modelBaseStyles.BorderRight.Width.Value)

                If parentBorderleftValue <> 0 Then outer += parentBorderleftValue Else outer += parentBorderValue
                If parentborderRightValue <> 0 Then outer += parentborderRightValue Else outer += parentBorderValue

                outer += parentPaddingLeftValue + parentborderRightValue

            End If

            Dim paddingLeftValue As Integer = 0
            Dim paddingRightValue As Integer = 0
            Dim marginLeftValue As Integer = 0
            Dim marginRightValue As Integer = 0

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Padding.Left.Value) Then Integer.TryParse(styleZone.BaseStyles.Padding.Left.Value, paddingLeftValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Padding.Left.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Padding.Left.Value, paddingLeftValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Padding.Right.Value) Then Integer.TryParse(styleZone.BaseStyles.Padding.Right.Value, paddingRightValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Padding.Right.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Padding.Right.Value, paddingRightValue)

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Margin.Left.Value) Then Integer.TryParse(styleZone.BaseStyles.Margin.Left.Value, marginLeftValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Margin.Left.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Margin.Left.Value, marginLeftValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Margin.Right.Value) Then Integer.TryParse(styleZone.BaseStyles.Margin.Right.Value, marginRightValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Margin.Right.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Margin.Right.Value, marginRightValue)

            Dim borderValue As Integer = 0
            Dim borderLeftValue As Integer = 0
            Dim borderRightValue As Integer = 0

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Border.Width.Value) AndAlso styleZone.BaseStyles.Border.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.Border.Width.Value, borderValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Border.Width.Value) AndAlso modelStyleZone.BaseStyles.Border.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.Border.Width.Value, borderValue)

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.BorderLeft.Width.Value) AndAlso styleZone.BaseStyles.BorderLeft.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.BorderLeft.Width.Value, borderLeftValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.BorderLeft.Width.Value) AndAlso modelStyleZone.BaseStyles.BorderLeft.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.BorderLeft.Width.Value, borderLeftValue)

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.BorderRight.Width.Value) AndAlso styleZone.BaseStyles.BorderRight.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.BorderRight.Width.Value, borderRightValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.BorderRight.Width.Value) AndAlso modelStyleZone.BaseStyles.BorderRight.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.BorderRight.Width.Value, borderRightValue)

            If borderLeftValue <> 0 Then outer += borderLeftValue Else outer += borderValue
            If borderRightValue <> 0 Then outer += borderRightValue Else outer += borderValue

            outer += paddingLeftValue + paddingRightValue + marginLeftValue + marginRightValue

            Return outer
        End Function

        ''' <summary>
        '''  Image resized at the specific height (Priority: vertical) 
        ''' </summary>
        ''' <param name="newImageWidth"></param>
        ''' <remarks></remarks>
        Private Sub ResizeImage(ByVal newImageWidth As Integer)
            If Me.ImagesList.Images.Count = 0 Then Exit Sub 'no action

            Dim resizeConfig As Picture.PictureResizeConfig = New Picture.PictureResizeConfig(New Size(newImageWidth, newImageWidth), Enu.EnuPriorityImageResize.Horizontal, False, False)
            Me.ImagesList.Resize(Me, resizeConfig, Nothing, Nothing, _ResizeAllPictures)
            _ResizeAllPictures = False
        End Sub

        ''' <summary>
        ''' calculate for the images list, of the new sizes.
        ''' </summary>
        ''' <param name="innerHeight">Internal height of image who to be used in calculations (padding and border)</param> 
        ''' <remarks> involve that if the resize has not been doing, we load the original source path and do the ratio calculation</remarks>
        Private Sub SearchDimImage(ByVal innerHeight As Integer)
            If ImagesList.Images.Count = 0 Then Exit Sub

            Dim newImagesInfo = New List(Of ImagesInfos)

            For Each Image In Me.ImagesList.Images
                Dim thisImageHeight As Integer
                Dim thisImageWidth As Integer = Me.DivImageWidth

                Dim resizeLink As Link

                Dim originImageWidth = Image.LinkOrigin.ImageSize.Width
                Dim originImageHeigth = Image.LinkOrigin.ImageSize.Height
                If originImageWidth = 0 OrElse originImageHeigth = 0 Then
                    'we open the image
                    Dim filePath As String = MyBase.GetLinkIOPath(Image.LinkOrigin, MyBase.Page.Culture)
                    Dim img As OBitmap = MyBase.OpenBitmap(filePath)
                    If img Is Nothing Then
                        OEMsgBox(LocalizableFormAndConverter._0173 & vbCrLf & filePath, MsgBoxType.Err, LocalizableFormAndConverter._0155) '"L'image au chemin d'accès suivant est corrompu et ne pourra donc être affichée. "  |  "Image incorrect"
                        MyBase.CloseBitmap(img)
                        Continue For 'we can't open the image
                    End If
                    originImageHeigth = img.Height
                    originImageWidth = img.Width
                    If originImageWidth = 0 OrElse originImageHeigth = 0 Then
                        OEMsgBox(LocalizableFormAndConverter._0173 & vbCrLf & filePath, MsgBoxType.Err, LocalizableFormAndConverter._0155) 'L'image au chemin d'accès suivant est corrompu et ne pourra donc être affichée.  |  "Image incorrect"
                        MyBase.CloseBitmap(img)
                        Continue For 'we can't open the image
                    End If
                    MyBase.CloseBitmap(img)
                End If

                'Proportional calculation

                thisImageHeight = (thisImageWidth * originImageHeigth) / (originImageWidth)

                'special case where height/width isn't compatible with the images
                If thisImageHeight > DivImageHeight Then
                    'we must recalculate the size
                    thisImageHeight = DivImageHeight
                    thisImageWidth = (thisImageHeight * originImageWidth) / (originImageHeigth)
                    _BadProportionImg = True
                End If

                If thisImageHeight = 0 OrElse Image.UpdateSize = True Then
                    'not automatic resizing ! we take the images's source
                    resizeLink = Image.LinkOrigin
                Else
                    resizeLink = Image.LinkSize1
                End If
                newImagesInfo.Add(New ImagesInfos(resizeLink, Image.LinkOrigin, Image.PageLink, thisImageHeight, thisImageHeight + innerHeight, thisImageWidth, 0, Image.Title))
            Next

            Me._ImagesInfo = newImagesInfo
        End Sub

        #End Region 'Methods

        #Region "Other"

        'Private Sub AddFolderImage(ByVal actionArg As Wait.ActionArg(Of IO.FileInfo(), List(Of Object)))
        '    Dim fileNames As IO.FileInfo() = actionArg.Argument1
        '    Dim newObs As List(Of Object) = actionArg.Argument2
        '    For Each file As IO.FileInfo In fileNames
        '        If Tools.Various.GetFileType(file.Extension) <> Tools.Enu.FilesMapType.Image Then Continue For
        '        Dim image As New GalleryImages.GalleryImageInfo(Me, file.FullName, ImagesList.GalleryForderLink, Me.Page.Culture)
        '        newObs.Add(image)
        '        Windows.Forms.Application.DoEvents()
        '    Next
        'End Sub

        #End Region 'Other

    End Class

End Namespace

