Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Web.UI
Imports System.Windows.Forms

Imports openElement
Imports openElement.Tools
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Common.Attributes.EditListOf
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

    #Region "Enumerations"

    Public Enum EnuCarrouselHorizontalDirection As Short
        GoToLeft = 0
        GoToRight = 1
    End Enum

    Public Enum EnuCarrouselTypeEffect As Short
        LinearLinear = 0
        'linear_swing = 1
        Sequential = 2
    End Enum

    Public Enum EnuCarrouselVerticalDirection As Short
        GoToTop = 0
        GoToBottom = 1
    End Enum

    #End Region 'Enumerations

    ''' <summary>
    ''' generic Images config (render in js file)
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable> _
    Public Class ImagesInfos

        #Region "Fields"

        Private _ImageOriginURL As Link
        Private _ImageURL As Link
        Private _ImgHeight As Integer
        Private _ImgOuterHeight As Integer
        Private _ImgOuterWidth As Integer
        Private _ImgWidth As Integer
        Private _PageLink As Link
        Private _Title As LocalizableString

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal imageResizeUrl As Link, ByVal imageOrigineUrl As Link, ByVal imgPageLink As Link, ByVal imgHeight As Integer, _
            ByVal imgOuterHeight As Integer, ByVal imgWidth As Integer, ByVal imgOuterWidth As Integer, ByVal imgTitle As LocalizableString)
            _ImageURL = imageResizeUrl
            _ImageOriginURL = imageOrigineUrl
            _PageLink = imgPageLink

            _Title = imgTitle

            _ImgHeight = imgHeight
            _ImgOuterHeight = imgOuterHeight
            _ImgWidth = imgWidth
            _ImgOuterWidth = imgOuterWidth
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        ''' <summary>
        ''' source image's url (can be equal to the imgURL)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ImageOriginURL() As Link
            Get
                Return _ImageOriginURL
            End Get
        End Property

        ''' <summary>
        ''' resize image height   
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <IsListOfObject> _
        Public ReadOnly Property ImgHeight() As Integer
            Get
                Return _ImgHeight
            End Get
        End Property

        ''' <summary>
        ''' image height with border and padding
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <IsListOfObject> _
        Public ReadOnly Property ImgOuterHeight() As Integer
            Get
                Return _ImgOuterHeight
            End Get
        End Property

        ''' <summary>
        ''' image width with border and padding
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <IsListOfObject> _
        Public ReadOnly Property ImgOuterWidth() As Integer
            Get
                Return _ImgOuterWidth
            End Get
        End Property

        ''' <summary>
        ''' html image's url
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <IsListOfObject> _
        Public ReadOnly Property ImgURL() As Link
            Get
                Return _ImageURL
            End Get
        End Property

        ''' <summary>
        ''' resize image width
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <IsListOfObject> _
        Public ReadOnly Property ImgWidth() As Integer
            Get
                Return _ImgWidth
            End Get
        End Property

        ''' <summary>
        '''link on the mouseclick event 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <IsListOfObject> _
        Public ReadOnly Property PageLink() As Link
            Get
                Return _PageLink
            End Get
        End Property

        ''' <summary>
        ''' image's title,(alternate text)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Title() As LocalizableString
            Get
                Return _Title
            End Get
        End Property

        #End Region 'Properties

    End Class

    ''' <summary>
    ''' horizontal carrousel 
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable> _
    Public Class WEGalleryCarrousel1
        Inherits ElementBase

        #Region "Fields"

        Private _Auto As Boolean
        Private _AutoWaitingTime As Integer
        Private _BadProportionImg As Boolean = False
        <NonSerialized> _
        Private _CssUpdate As Boolean
        Private _Decalage As Integer
        <NonSerialized> _
        Private _DivImageHeight2 As Integer
        <NonSerialized> _
        Private _DivImageWidth2 As Integer

        ''' <summary>
        ''' Visual effect
        ''' </summary>
        ''' <remarks></remarks>
        Private _Easing As EnumEasingEffect

        ''' <summary>
        ''' Config class write in the js file
        ''' </summary>
        ''' <remarks></remarks>
        Private _ImagesInfos As List(Of ImagesInfos)
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
        Private _Sens As EnuCarrouselHorizontalDirection
        Private _TypeEffect As EnuCarrouselTypeEffect
        Private _Vitesse As Integer

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEGalleryCarrousel1", page, parentID, templateName)
            MyBase.NumUpdate = 1
            'Default values
            Me.Sens = EnuCarrouselHorizontalDirection.GoToLeft
            Me.Vitesse = 1000
            Me._ResizeAllPictures = True
            Me.AutoWaitingTime = 1000
            Me.Easing = EnumEasingEffect.none
            DivImageHeight = 100
            DivImageWidth = 550
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Settings), _
        Ressource.localizable.LocalizableNameAtt("_N120"), _
        LocalizableDescAtt("_D120"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Auto() As Boolean
            Get
                Return _Auto
            End Get
            Set(ByVal value As Boolean)
                _Auto = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Settings), _
        Ressource.localizable.LocalizableNameAtt("_N119"), _
        LocalizableDescAtt("_D119"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property AutoWaitingTime() As Integer
            Get
                Return _AutoWaitingTime
            End Get
            Set(ByVal value As Integer)
                _AutoWaitingTime = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Settings), _
        Ressource.localizable.LocalizableNameAtt("_N118"), _
        LocalizableDescAtt("_D118"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Decalage() As Integer
            Get
                If _Decalage <= 0 Then _Decalage = 1
                Return _Decalage
            End Get
            Set(ByVal value As Integer)
                _Decalage = value
            End Set
        End Property

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

        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property EasingJs() As String
            Get
                Return _Easing.ToString
            End Get
        End Property

        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property ImagesInfo() As List(Of ImagesInfos)
            Get
                If _ImagesInfos Is Nothing Then _ImagesInfos = New List(Of ImagesInfos)
                Return _ImagesInfos
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

                Me.CalculateDimImages()

                If _BadProportionImg Then
                    OEMsgBox(LocalizableFormAndConverter._0200, MsgBoxType.Info, LocalizableFormAndConverter._0201)
                End If
                _BadProportionImg = False

            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Settings), _
        Ressource.localizable.LocalizableNameAtt("_N117"), _
        LocalizableDescAtt("_D117"), _
        TypeConverter(GetType(TConvEnuCarrouselDirection)), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Sens() As EnuCarrouselHorizontalDirection
            Get
                Return _Sens
            End Get
            Set(ByVal value As EnuCarrouselHorizontalDirection)
                _Sens = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Settings), _
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

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Settings), _
        Ressource.localizable.LocalizableNameAtt("_N121"), _
        LocalizableDescAtt("_D121"), _
        ExportVar(ExportVar.EnuVarType.Js), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Vitesse() As Integer
            Get
                Return _Vitesse
            End Get
            Set(ByVal value As Integer)
                _Vitesse = value
            End Set
        End Property

        ''' <summary>
        ''' true if the css has been update there  we must  recalculate the images's dimensions
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

        <Browsable(False)> _
        Private Property DivImageHeight() As Integer
            Set(ByVal value As Integer)
                _DivImageHeight2 = value
            End Set
            Get
                If _DivImageHeight2 = 0 Then Call Me.Calculate_ImagesHeigth(MyBase.StylesSkin.FindStylesZone("Images"), GetModelZoneImageSafe())
                Return _DivImageHeight2
            End Get
        End Property

        <Browsable(False)> _
        Private Property DivImageWidth() As Integer
            Set(ByVal value As Integer)
                _DivImageWidth2 = value
            End Set
            Get
                If _DivImageWidth2 = 0 Then Call Me.Calculate_DivImageWidth()
                Return _DivImageWidth2
            End Get
        End Property

        #End Region 'Properties

        #Region "Methods"

        ''' <summary>
        '''  After the css update, shows if the recalculation of carrousel is necessary
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
            info.ToolBoxCaption = LocalizableOpen._0128
            info.VersionMajor = 2
            info.VersionMinor = 0
            info.GroupName = "NBGroupMedia"
            info.ToolBoxIco = My.Resources.WECarrousel1
            info.ToolBoxDescription = LocalizableOpen._0127
            info.AutoOpenProperty = "ImagesList"
            info.SortPropertyList.Add(New SortProperty("ImagesList", "Tools.png", LocalizableOpen._0199))
            Return info
        End Function

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(EnuScriptType.Css, "ElementsLibrary\Common\Css\WEGalleryCarrousel1.css", "WEFiles/Css/WEGalleryCarrousel1.css")
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEGalleryCarrousel1.js", "WEFiles/Client/WEGalleryCarrousel1.js")
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
            configStylesZones.Add(New ConfigStylesZone("Images", LocalizableOpen._0129, LocalizableOpen._0130))
            configStylesZones.Add(New ConfigStylesZone("Previous", LocalizableOpen._0131, LocalizableOpen._0132))
            configStylesZones.Add(New ConfigStylesZone("Next", LocalizableOpen._0133, LocalizableOpen._0134))

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub OnPageBeforeRender(ByVal mode As Page.EnuTypeRenderMode)
            ' we must recalculate the size if the css (border,margin,padding) has been modified
            If Me.Page.RenderMode = Page.EnuTypeRenderMode.Export AndAlso CssUpdate Then

                For Each image As GalleryImages.GalleryImageInfo In ImagesList.Images
                    image.UpdateSize = True
                Next

                Me.DivImageHeight = 0 'Force the height calculation
                Me.DivImageWidth = 0 'Force the width calculation

                Call CalculateDimImages()

                CssUpdate = False
            End If

            MyBase.OnPageBeforeRender(mode)
        End Sub

        ''' <summary>
        ''' events on the saving or cloning
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnPageSave()
            'we resize the images only we must do it
            Call ResizeImage(DivImageHeight)

            Call CalculateDimImages() 'very (VERY) essential

            MyBase.OnSave()
        End Sub

        Protected Overrides Sub OnResizeEnd()
            'force the resizing of images and margins
            _ResizeAllPictures = True
            For Each image As GalleryImages.GalleryImageInfo In ImagesList.Images
                image.UpdateSize = True
            Next

            Me.DivImageHeight = 0 'force the height calculation
            Me.DivImageWidth = 0 'force the width calculation
            Call CalculateDimImages() 'calculation at the saving and the preview

            If _BadProportionImg Then
                OEMsgBox(LocalizableFormAndConverter._0200, MsgBoxType.Info, LocalizableFormAndConverter._0201)
            End If
            _BadProportionImg = False

            MyBase.OnResizeEnd()
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            'Private Sub RenderExportMode(ByRef writer As Common.HtmlWriter)
            MyBase.RenderBeginTag(writer)

            'Les buttons next and prev
            'If Me.Auto = False Then
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Previous"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()
            'End If

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "WECarrousel1Parent")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.Indent += 1
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "WECarrousel1ImagesParent")
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
                    Dim totalImgW As Integer = 0
                    For i As Integer = 0 To _NbImage - 1
                        totalImgW += ImagesInfo(i).ImgOuterWidth
                    Next
                    Dim mt As Integer = (Me.DivImageWidth - totalImgW) / (Me._NbImage + 1)
                    If mt < 0 Then mt = 0 'if the image is too large

                    Dim oldPosition = 0
                    Dim oldWidth = 0
                    Dim leftPosition

                    For i As Integer = 0 To _NbImage - 1
                        leftPosition = mt + oldPosition + oldWidth
                        oldPosition = leftPosition
                        oldWidth = ImagesInfo(i).ImgOuterWidth

                        Dim pageLink As String = MyBase.GetLink(ImagesInfo(i).PageLink, Me.Page.Culture)
                        Dim imgPath As String = MyBase.GetLink(ImagesInfo(i).ImgURL, Me.Page.Culture)

                        If String.IsNullOrEmpty(imgPath) Then
                            imgPath = MyBase.GetLink(ImagesInfo(i).ImageOriginURL, Me.Page.Culture)
                        End If

                        writer.WriteBeginTag("div")
                        writer.WriteAttribute("class", "CarrouselH_Img")
                        writer.WriteAttribute("style", String.Concat("height:", ImagesInfo(i).ImgHeight.ToString, "px ; width:" & ImagesInfo(i).ImgWidth.ToString & "px; left:", leftPosition.ToString, "px;"))
                        writer.Write(HtmlTextWriter.TagRightChar)

                        'specific html code of image
                        If Not String.IsNullOrEmpty(pageLink) Then
                            writer.WriteBeginTag("a")
                            writer.WriteHrefAttribute(Me, ImagesInfo(i).PageLink, True)
                            writer.Write(HtmlTextWriter.TagRightChar)
                        End If

                        writer.WriteBeginTag("img")
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

            Dim paddingBorderWidth As Integer = Me.OuterPbWidth(imagesZone, modelSkinImagesZone) 'must be used for the dimensions calculation  of the images
            Dim marginWidth As Integer = Me.OuterMarginWidth(imagesZone, modelSkinImagesZone)   'must be used for the numbers images calculation

            'calculation of width margin starting from this height > to imagesInfo
            'we use also the padding and the border of image
            Call SearchDimImage(paddingBorderWidth)

            'we must find the initial images number(initial first last last index find by js)
            Dim baseWidth As Integer = 0
            _NbImage = 0

            For Each image As ImagesInfos In Me.ImagesInfo
                baseWidth = baseWidth + (image.ImgOuterWidth + marginWidth)
                If baseWidth < Me.DivImageWidth Then _NbImage = _NbImage + 1 Else Exit For
            Next

            If Me.ImagesInfo.Count <> 0 AndAlso _NbImage = 0 Then
                'special case where the first image is greater of the carrousel's width
                _NbImage = 1
            End If
        End Sub

        Private Sub Calculate_DivImageWidth()
            If Not String.IsNullOrEmpty(MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value) _
                AndAlso IsNumeric(MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value) Then
                DivImageWidth = Integer.Parse(MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value)
                Exit Sub
            End If

            Dim modelSkin As StylesZone = GetModelZoneImageSafe()

            'style model if the element's value is none
            If Not String.IsNullOrEmpty(modelSkin.BaseStyles.Width.Value) AndAlso IsNumeric(modelSkin.BaseStyles.Width.Value) Then DivImageWidth = Integer.Parse(modelSkin.BaseStyles.Width.Value)
        End Sub

        Private Sub Calculate_ImagesHeigth(ByVal imagesZone As StylesZone, ByVal modelSkinImagesZone As StylesZone)
            ' special case where we are no image's height
            If Not String.IsNullOrEmpty(imagesZone.BaseStyles.Height.Value) AndAlso IsNumeric(imagesZone.BaseStyles.Height.Value) Then
                _DivImageHeight2 = Integer.Parse(imagesZone.BaseStyles.Height.Value)
            Else
                Dim modelSkin As StylesZone = GetModelZoneImageSafe()
                Dim modelHeight As String = modelSkin.BaseStyles.Height.Value
                If Not String.IsNullOrEmpty(modelHeight) AndAlso IsNumeric(modelHeight) Then _DivImageHeight2 = Integer.Parse(modelHeight) : Exit Sub

                Dim baseDivHeigthValue As String = MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Value
                If Not String.IsNullOrEmpty(baseDivHeigthValue) AndAlso IsNumeric(baseDivHeigthValue) Then _DivImageHeight2 = Integer.Parse(baseDivHeigthValue)

                Dim outerHeight As Integer = Me.OuterHeight(imagesZone, modelSkinImagesZone, True)
                If outerHeight <> 0 Then _DivImageHeight2 = _DivImageHeight2 - outerHeight
            End If
        End Sub

        Private Function GetModelZoneImageSafe() As StylesZone
            Return WEGalleryCarrousel2.GetModelStyleZoneSafe(MyBase.StylesSkin)
        End Function

        ''' <summary>
        ''' search outer dimension for the styleZone
        ''' </summary>
        ''' <param name="styleZone"></param>
        ''' <param name="withParent">true if we include the parent's padding</param>
        ''' <returns></returns>
        ''' <remarks>no margin because the position is 'absolute'  ONLY PADDING ET BORDER</remarks>
        Private Function OuterHeight(ByVal styleZone As StylesZone, ByVal modelStyleZone As StylesZone, ByVal withParent As Boolean) As Integer
            Dim outer As Integer = 0

            If withParent Then
                Dim parentStyle As Styles = MyBase.StylesSkin.BaseDiv.BaseStyles
                Dim modelBase As Styles = MyBase.StylesSkin.StylesSkinModel.BaseDiv.BaseStyles

                Dim parentBorderValue As Integer = 0
                Dim parentBorderTopValue As Integer = 0
                Dim parentborderBottomValue As Integer = 0
                Dim parentPaddingTopValue As Integer = 0
                Dim parentPaddingBottomValue As Integer = 0

                'parent's PADDING
                If Not String.IsNullOrEmpty(parentStyle.Padding.Top.Value) Then Integer.TryParse(parentStyle.Padding.Top.Value, parentPaddingTopValue) Else _
                    If Not String.IsNullOrEmpty(modelBase.Padding.Top.Value) Then Integer.TryParse(modelBase.Padding.Top.Value, parentPaddingTopValue)
                If Not String.IsNullOrEmpty(parentStyle.Padding.Bottom.Value) Then Integer.TryParse(parentStyle.Padding.Bottom.Value, parentPaddingBottomValue) Else _
                    If Not String.IsNullOrEmpty(modelBase.Padding.Bottom.Value) Then Integer.TryParse(modelBase.Padding.Bottom.Value, parentPaddingTopValue)
                'parent's BORDER
                If Not String.IsNullOrEmpty(parentStyle.Border.Width.Value) AndAlso parentStyle.Border.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(parentStyle.Border.Width.Value, parentBorderValue) Else _
                    If Not String.IsNullOrEmpty(modelBase.Border.Width.Value) AndAlso modelBase.Border.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(modelBase.Border.Width.Value, parentBorderValue)
                If Not String.IsNullOrEmpty(parentStyle.BorderTop.Width.Value) AndAlso parentStyle.BorderTop.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(parentStyle.BorderTop.Width.Value, parentBorderTopValue) Else _
                    If Not String.IsNullOrEmpty(modelBase.BorderTop.Width.Value) AndAlso modelBase.BorderTop.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(modelBase.BorderTop.Width.Value, parentBorderTopValue)
                If Not String.IsNullOrEmpty(parentStyle.BorderBottom.Width.Value) AndAlso parentStyle.BorderBottom.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(parentStyle.BorderBottom.Width.Value, parentborderBottomValue) Else _
                    If Not String.IsNullOrEmpty(modelBase.BorderBottom.Width.Value) AndAlso modelBase.BorderBottom.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(modelBase.BorderBottom.Width.Value, parentborderBottomValue)

                If parentBorderTopValue <> 0 Then outer += parentBorderTopValue Else outer += parentBorderValue
                If parentborderBottomValue <> 0 Then outer += parentborderBottomValue Else outer += parentBorderValue

                outer += parentPaddingBottomValue + parentPaddingTopValue

            End If

            Dim borderValue As Integer = 0
            Dim borderTopValue As Integer = 0
            Dim borderBottomValue As Integer = 0
            Dim paddingTopValue As Integer = 0
            Dim paddingBottomValue As Integer = 0
            Dim marginTopValue As Integer = 0
            Dim marginBottomValue As Integer = 0
            'element's PADDING
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Padding.Top.Value) Then Integer.TryParse(styleZone.BaseStyles.Padding.Top.Value, paddingTopValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Padding.Top.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Padding.Top.Value, paddingTopValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Padding.Bottom.Value) Then Integer.TryParse(styleZone.BaseStyles.Padding.Bottom.Value, paddingBottomValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Padding.Bottom.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Padding.Bottom.Value, paddingBottomValue)
            'element's MARGIN
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Margin.Top.Value) Then Integer.TryParse(styleZone.BaseStyles.Margin.Top.Value, marginTopValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Margin.Top.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Margin.Top.Value, marginTopValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Margin.Bottom.Value) Then Integer.TryParse(styleZone.BaseStyles.Margin.Bottom.Value, marginBottomValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Margin.Bottom.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Margin.Bottom.Value, marginBottomValue)
            'element's BORDER
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Border.Width.Value) AndAlso styleZone.BaseStyles.Border.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.Border.Width.Value, borderValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Border.Width.Value) AndAlso modelStyleZone.BaseStyles.Border.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.Border.Width.Value, borderValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.BorderTop.Width.Value) AndAlso styleZone.BaseStyles.BorderTop.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.BorderTop.Width.Value, borderTopValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.BorderTop.Width.Value) AndAlso modelStyleZone.BaseStyles.BorderTop.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.BorderTop.Width.Value, borderTopValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.BorderBottom.Width.Value) AndAlso styleZone.BaseStyles.BorderBottom.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.BorderBottom.Width.Value, borderBottomValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.BorderBottom.Width.Value) AndAlso modelStyleZone.BaseStyles.BorderBottom.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.BorderBottom.Width.Value, borderBottomValue)

            If borderTopValue <> 0 Then outer += borderTopValue Else outer += borderValue
            If borderBottomValue <> 0 Then outer += borderBottomValue Else outer += borderValue

            outer += paddingTopValue + paddingBottomValue + marginTopValue + marginBottomValue

            Return outer
        End Function

        ''' <summary>
        ''' research for the style zone of the margin-left and margin-right
        ''' </summary>
        ''' <param name="styleZone"></param>
        ''' <returns></returns>
        ''' <remarks>no use the parent's div and ONLY MARGIN</remarks>
        Private Function OuterMarginWidth(ByVal styleZone As StylesZone, ByVal modelStyleZone As StylesZone) As Integer
            If styleZone Is Nothing OrElse modelStyleZone Is Nothing Then Return 0

            Dim outer As Integer = 0

            Dim marginLeftValue As Integer = 0
            Dim marginRightValue As Integer = 0

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Margin.Left.Value) Then Integer.TryParse(styleZone.BaseStyles.Margin.Left.Value, marginLeftValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Margin.Left.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Margin.Left.Value, marginLeftValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Margin.Right.Value) Then Integer.TryParse(styleZone.BaseStyles.Margin.Right.Value, marginRightValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Margin.Right.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Margin.Right.Value, marginRightValue)

            outer += marginLeftValue + marginRightValue
            Return outer
        End Function

        ''' <summary>
        ''' search the added dimension  (inside :padding and border)
        ''' </summary>
        ''' <param name="styleZone"></param>
        ''' <param name="modelStyleZone"></param>
        ''' <returns></returns>
        ''' <remarks>Only Padding et Border</remarks>
        Private Function OuterPbWidth(ByVal styleZone As StylesZone, ByVal modelStyleZone As StylesZone) As Integer
            If styleZone Is Nothing OrElse modelStyleZone Is Nothing Then Return 0

            Dim inner As Integer = 0

            Dim borderValue As Integer = 0
            Dim borderLeftValue As Integer = 0
            Dim borderRightValue As Integer = 0
            Dim paddingLeftValue As Integer = 0
            Dim paddingRightValue As Integer = 0

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Padding.Left.Value) Then Integer.TryParse(styleZone.BaseStyles.Padding.Left.Value, paddingLeftValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Padding.Left.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Padding.Left.Value, paddingLeftValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Padding.Right.Value) Then Integer.TryParse(styleZone.BaseStyles.Padding.Right.Value, paddingRightValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Padding.Right.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Padding.Right.Value, paddingRightValue)

            'special cas of border : used only if the style is known. (border-left and border-right on border priority)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Border.Width.Value) AndAlso styleZone.BaseStyles.Border.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.Border.Width.Value, borderValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Border.Width.Value) AndAlso modelStyleZone.BaseStyles.Border.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.Border.Width.Value, borderValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.BorderLeft.Width.Value) AndAlso styleZone.BaseStyles.BorderLeft.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.BorderLeft.Width.Value, borderLeftValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.BorderLeft.Width.Value) AndAlso modelStyleZone.BaseStyles.BorderLeft.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.BorderLeft.Width.Value, borderLeftValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.BorderRight.Width.Value) AndAlso styleZone.BaseStyles.BorderRight.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.BorderRight.Width.Value, borderRightValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.BorderRight.Width.Value) AndAlso modelStyleZone.BaseStyles.BorderRight.Style <> CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.BorderRight.Width.Value, borderRightValue)

            If borderLeftValue <> 0 Then inner += borderLeftValue Else inner += borderValue
            If borderRightValue <> 0 Then inner += borderRightValue Else inner += borderValue

            inner += paddingLeftValue + paddingRightValue

            Return inner
        End Function

        ''' <summary>
        ''' Image resized at the specific height (Priority: vertical) 
        ''' </summary>
        ''' <param name="newImageHeigth"></param>
        ''' <remarks></remarks>
        Private Sub ResizeImage(ByVal newImageHeigth As Integer)
            If Me.ImagesList.Images.Count = 0 Then Exit Sub

            Dim resizeConfig As Picture.PictureResizeConfig = New Picture.PictureResizeConfig(New Size(newImageHeigth, newImageHeigth), Enu.EnuPriorityImageResize.Vertical, False, False)
            Me.ImagesList.Resize(Me, resizeConfig, Nothing, Nothing, _ResizeAllPictures)
            _ResizeAllPictures = False
        End Sub

        Private Sub SearchDimImage(ByVal innerWidth As Integer)
            If ImagesList.Images.Count = 0 Then Exit Sub

            Dim newImagesInfo = New List(Of ImagesInfos)

            For Each Image In Me.ImagesList.Images
                Dim thisImageWidth As Integer
                Dim thisImageHeight As Integer = DivImageHeight

                Dim resizeLink As Link

                Dim originImageWidth = Image.LinkOrigin.ImageSize.Width
                Dim originImageHeigth = Image.LinkOrigin.ImageSize.Height

                If originImageWidth = 0 OrElse originImageHeigth = 0 Then
                    'we open the image
                    Dim filePath As String = MyBase.GetLinkIOPath(Image.LinkOrigin, MyBase.Page.Culture)
                    Dim img As OBitmap = MyBase.OpenBitmap(filePath)
                    If img Is Nothing Then
                        OEMsgBox(LocalizableFormAndConverter._0154 & vbCrLf & filePath, MsgBoxType.Err, LocalizableFormAndConverter._0155)
                        MyBase.CloseBitmap(img)
                        Continue For 'we can't open the image
                    End If
                    originImageHeigth = img.Height
                    originImageWidth = img.Width
                    If originImageWidth = 0 OrElse originImageHeigth = 0 Then
                        OEMsgBox(LocalizableFormAndConverter._0154 & vbCrLf & filePath, MsgBoxType.Err, LocalizableFormAndConverter._0155)
                        MyBase.CloseBitmap(img)
                        Continue For 'we can't open the image
                    End If
                    MyBase.CloseBitmap(img)
                End If

                'Proportional calculation
                thisImageWidth = (thisImageHeight * originImageWidth) / (originImageHeigth)

                'special case where height/width isn't compatible with the images
                If thisImageWidth > DivImageWidth Then
                    'we must recalculate the size
                    thisImageWidth = DivImageWidth
                    thisImageHeight = (thisImageWidth * originImageHeigth) / (originImageWidth)
                    _BadProportionImg = True
                End If

                If thisImageWidth = 0 OrElse Image.UpdateSize = True Then
                    'not automatic resizing ! we take the images's source
                    resizeLink = Image.LinkOrigin
                Else
                    resizeLink = Image.LinkSize1
                End If

                newImagesInfo.Add(New ImagesInfos(resizeLink, Image.LinkOrigin, Image.PageLink, thisImageHeight, 0, thisImageWidth, thisImageWidth + innerWidth, Image.Title))

            Next

            Me._ImagesInfos = newImagesInfo
        End Sub

        #End Region 'Methods

        #Region "Nested Types"

        ''' <summary>
        ''' Obsolete class, use ImagesInfos
        ''' </summary>
        ''' <remarks></remarks>
        <Serializable, _
        Obsolete> _
        Public Class ImageInfo

            #Region "Fields"

            Private _ImageOriginPath As String
            Private _ImagePath As String
            Private _ImgHeight As Integer
            Private _ImgOuterHeight As Integer
            Private _ImgOuterWidth As Integer
            Private _ImgWidth As Integer
            Private _PageLink As String

            #End Region 'Fields

            #Region "Constructors"

            Public Sub New(ByVal imageResizePath As String, ByVal imageOriginePath As String, ByVal imgPageLink As String, ByVal imgHeight As Integer, _
                ByVal imgOuterHeight As Integer, ByVal imgWidth As Integer, ByVal imgOuterWidth As Integer)
                _ImagePath = imageResizePath
                _ImageOriginPath = imageOriginePath
                _PageLink = imgPageLink

                _ImgHeight = imgHeight
                _ImgOuterHeight = imgOuterHeight
                _ImgWidth = imgWidth
                _ImgOuterWidth = imgOuterWidth
            End Sub

            #End Region 'Constructors

            #Region "Properties"

            Public ReadOnly Property ImageOriginPath() As String
                Get
                    Return _ImageOriginPath
                End Get
            End Property

            <IsListOfObject> _
            Public ReadOnly Property ImgHeight() As Integer
                Get
                    Return _ImgHeight
                End Get
            End Property

            <IsListOfObject> _
            Public ReadOnly Property ImgOuterHeight() As Integer
                Get
                    Return _ImgOuterHeight
                End Get
            End Property

            <IsListOfObject> _
            Public ReadOnly Property ImgOuterWidth() As Integer
                Get
                    Return _ImgOuterWidth
                End Get
            End Property

            <IsListOfObject> _
            Public ReadOnly Property ImgPath() As String
                Get
                    Return _ImagePath
                End Get
            End Property

            <IsListOfObject> _
            Public ReadOnly Property ImgWidth() As Integer
                Get
                    Return _ImgWidth
                End Get
            End Property

            <IsListOfObject> _
            Public ReadOnly Property PageLink() As String
                Get
                    Return _PageLink
                End Get
            End Property

            #End Region 'Properties

        End Class

        #End Region 'Nested Types

        #Region "Other"

        'Private Sub AddFolderImage(ByVal actionArg As Wait.ActionArg(Of IO.FileInfo(), List(Of Object)))
        '    Dim fileNames As IO.FileInfo() = actionArg.Argument1
        '    Dim newObs As List(Of Object) = actionArg.Argument2
        '    For Each file As IO.FileInfo In fileNames
        '        If Tools.Various.GetFileType(file.Extension) <> Tools.Enu.FilesMapType.Image Then Continue For
        '        'traitement des images
        '        Dim image As New GalleryImages.GalleryImageInfo(Me, file.FullName, ImagesList.GalleryForderLink, Me.Page.Culture)
        '        newObs.Add(image)
        '        Windows.Forms.Application.DoEvents()
        '    Next
        'End Sub

        #End Region 'Other

    End Class

End Namespace

