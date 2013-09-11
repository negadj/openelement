Imports openElement
Imports openElement.WebElement
Imports openElement.WebElement.Elements
Imports System.ComponentModel
Imports System.Drawing
Imports openElement.WebElement.DataType
Imports openElement.WebElement.Editors.Control.CtlEditListOf
Imports openElement.WebElement.StylesManager
Imports System.Windows.Forms

Namespace Elements.Media

#Region "For the 2 gallery carousel"
    Public Enum EnuCarrousel_HorizontalDirection As Short
        GoToLeft = 0
        GoToRight = 1
    End Enum

    Public Enum EnuCarrousel_VerticalDirection As Short
        GoToTop = 0
        GoToBottom = 1
    End Enum

    Public Enum EnuCarrousel_TypeEffect As Short
        linear_linear = 0
        'linear_swing = 1
        sequential = 2
    End Enum

    ''' <summary>
    ''' generic Images config (render in js file)
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class ImagesInfos

        Private _ImageURL As LinksManager.Link
        Private _ImageOriginURL As LinksManager.Link
        Private _PageLink As LinksManager.Link

        Private _ImgHeight As Integer
        Private _ImgOuterHeight As Integer
        Private _ImgWidth As Integer
        Private _ImgOuterWidth As Integer

        Private _Title As DataType.LocalizableString

        ''' <summary>
        ''' html image's url
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Common.Attributes.EditListOf.IsListOfObject()> _
        Public ReadOnly Property ImgURL() As LinksManager.Link
            Get
                Return _ImageURL
            End Get
        End Property
        ''' <summary>
        ''' source image's url (can be equal to the imgURL)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ImageOriginURL() As LinksManager.Link
            Get
                Return _ImageOriginURL
            End Get
        End Property
        ''' <summary>
        '''link on the mouseclick event 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Common.Attributes.EditListOf.IsListOfObject()> _
        Public ReadOnly Property PageLink() As LinksManager.Link
            Get
                Return _PageLink
            End Get
        End Property

        ''' <summary>
        ''' resize image height   
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Common.Attributes.EditListOf.IsListOfObject()> _
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
        <Common.Attributes.EditListOf.IsListOfObject()> _
        Public ReadOnly Property ImgOuterHeight() As Integer
            Get
                Return _ImgOuterHeight
            End Get
        End Property
        ''' <summary>
        ''' resize image width
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Common.Attributes.EditListOf.IsListOfObject()> _
        Public ReadOnly Property ImgWidth() As Integer
            Get
                Return _ImgWidth
            End Get
        End Property

        ''' <summary>
        ''' image width with border and padding
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Common.Attributes.EditListOf.IsListOfObject()> _
        Public ReadOnly Property ImgOuterWidth() As Integer
            Get
                Return _ImgOuterWidth
            End Get
        End Property

        ''' <summary>
        ''' image's title,(alternate text)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Title() As DataType.LocalizableString
            Get
                Return _Title
            End Get
        End Property

        Public Sub New(ByVal imageResizeUrl As LinksManager.Link, ByVal imageOrigineUrl As LinksManager.Link, ByVal imgPageLink As LinksManager.Link, ByVal Img_Height As Integer, _
                       ByVal Img_OuterHeight As Integer, ByVal Img_Width As Integer, ByVal Img_OuterWidth As Integer, ByVal imgTitle As LocalizableString)
            _ImageURL = imageResizeUrl
            _ImageOriginURL = imageOrigineUrl
            _PageLink = imgPageLink

            _Title = imgTitle

            _ImgHeight = Img_Height
            _ImgOuterHeight = Img_OuterHeight
            _ImgWidth = Img_Width
            _ImgOuterWidth = Img_OuterWidth
        End Sub

    End Class

#End Region

    ''' <summary>
    ''' horizontal carrousel 
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class WEGalleryCarrousel1
        Inherits ElementBase

        ''' <summary>
        ''' Obsolete class, use ImagesInfos
        ''' </summary>
        ''' <remarks></remarks>
        <Serializable(), Obsolete()> _
        Public Class ImageInfo
            Private _ImagePath As String
            Private _ImageOriginPath As String
            Private _PageLink As String

            Private _ImgHeight As Integer
            Private _ImgOuterHeight As Integer
            Private _ImgWidth As Integer
            Private _ImgOuterWidth As Integer

            <Common.Attributes.EditListOf.IsListOfObject()> _
            Public ReadOnly Property ImgPath() As String
                Get
                    Return _ImagePath
                End Get
            End Property

            Public ReadOnly Property ImageOriginPath() As String
                Get
                    Return _ImageOriginPath
                End Get
            End Property

            <Common.Attributes.EditListOf.IsListOfObject()> _
            Public ReadOnly Property PageLink() As String
                Get
                    Return _PageLink
                End Get
            End Property

            <Common.Attributes.EditListOf.IsListOfObject()> _
            Public ReadOnly Property ImgHeight() As Integer
                Get
                    Return _ImgHeight
                End Get
            End Property

            <Common.Attributes.EditListOf.IsListOfObject()> _
            Public ReadOnly Property ImgOuterHeight() As Integer
                Get
                    Return _ImgOuterHeight
                End Get
            End Property

            <Common.Attributes.EditListOf.IsListOfObject()> _
            Public ReadOnly Property ImgWidth() As Integer
                Get
                    Return _ImgWidth
                End Get
            End Property

            <Common.Attributes.EditListOf.IsListOfObject()> _
            Public ReadOnly Property ImgOuterWidth() As Integer
                Get
                    Return _ImgOuterWidth
                End Get
            End Property

            Public Sub New(ByVal imageResizePath As String, ByVal imageOriginePath As String, ByVal imgPageLink As String, ByVal Img_Height As Integer, _
                           ByVal Img_OuterHeight As Integer, ByVal Img_Width As Integer, ByVal Img_OuterWidth As Integer)
                _ImagePath = imageResizePath
                _ImageOriginPath = imageOriginePath
                _PageLink = imgPageLink

                _ImgHeight = Img_Height
                _ImgOuterHeight = Img_OuterHeight
                _ImgWidth = Img_Width
                _ImgOuterWidth = Img_OuterWidth
            End Sub
        End Class

#Region "Properties"

        <Common.Attributes.ContainsLinks()> _
        Private _imagesList As DataType.GalleryImages

        ''' <summary>
        ''' Config class write in the js file
        ''' </summary>
        ''' <remarks></remarks>
        Private _imagesInfos As List(Of ImagesInfos)

        <Obsolete()> Private _imagesInfo1 As List(Of ImageInfo)

        <NonSerialized()> Private _CssUpdate As Boolean

        Private BadProportionImg As Boolean = False

#Region "Behavior specific variable (user config)"
        Private _Sens As EnuCarrousel_HorizontalDirection
        Private _infinite As Boolean
        Private _decalage As Integer
        Private _autoWaitingTime As Integer 
        Private _auto As Boolean
        Private _vitesse As Integer
        Private _TypeEffect As EnuCarrousel_TypeEffect

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
          Ressource.localizable.LocalizableNameAtt("_N117"), _
          Ressource.localizable.LocalizableDescAtt("_D117"), _
          TypeConverter(GetType(Editors.Converter.TConvEnuCarrouselDirection)), _
          Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
          Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
     Public Property Sens() As EnuCarrousel_HorizontalDirection
            Get
                Return _Sens
            End Get
            Set(ByVal value As EnuCarrousel_HorizontalDirection)
                _Sens = value
            End Set
        End Property
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
          Ressource.localizable.LocalizableNameAtt("_N138"), _
          Ressource.localizable.LocalizableDescAtt("_D138"), _
          TypeConverter(GetType(Editors.Converter.TConvEnuCarrouselTypeEffect)), _
          Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
          Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property TypeEffect() As EnuCarrousel_TypeEffect
            Get
                Return _TypeEffect
            End Get
            Set(ByVal value As EnuCarrousel_TypeEffect)
                _TypeEffect = value
            End Set
        End Property
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
            Ressource.localizable.LocalizableNameAtt("_N118"), _
            Ressource.localizable.LocalizableDescAtt("_D118"), _
            Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
            Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
          Public Property Decalage() As Integer
            Get
                If _decalage <= 0 Then _decalage = 1
                Return _decalage
            End Get
            Set(ByVal value As Integer)
                _decalage = value
            End Set
        End Property
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
            Ressource.localizable.LocalizableNameAtt("_N119"), _
            Ressource.localizable.LocalizableDescAtt("_D119"), _
            Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
            Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
         Public Property AutoWaitingTime() As Integer
            Get
                Return _autoWaitingTime
            End Get
            Set(ByVal value As Integer)
                _autoWaitingTime = value
            End Set
        End Property
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
            Ressource.localizable.LocalizableNameAtt("_N120"), _
            Ressource.localizable.LocalizableDescAtt("_D120"), _
            Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
            Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Auto() As Boolean
            Get
                Return _auto
            End Get
            Set(ByVal value As Boolean)
                _auto = value
            End Set
        End Property
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
            Ressource.localizable.LocalizableNameAtt("_N121"), _
            Ressource.localizable.LocalizableDescAtt("_D121"), _
            Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
            Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property Vitesse() As Integer
            Get
                Return _vitesse
            End Get
            Set(ByVal value As Integer)
                _vitesse = value
            End Set
        End Property
#End Region

        ''' <summary>
        ''' true if all images must be resized
        ''' </summary>
        ''' <remarks></remarks>
        <NonSerialized()> Private _ResizeAllPictures As Boolean
       
        <NonSerialized()> Private _DivImageHeight2 As Integer
        <NonSerialized()> Private _DivImageWidth2 As Integer

        ''' <summary>
        ''' display image's number at the first page load
        ''' </summary>
        ''' <remarks></remarks>
        Private _NbImage As Integer
        ''' <summary>
        ''' Visual effect
        ''' </summary>
        ''' <remarks></remarks>
        Private _Easing As DataType.Enum.EnumEasingEffect
        <NonSerialized()> Private _EasingJS As String

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

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
           Ressource.localizable.LocalizableNameAtt("_N116"), _
           Ressource.localizable.LocalizableDescAtt("_D116"), _
           Editor(GetType(openElement.WebElement.Editors.UITypeEditListOf), GetType(Drawing.Design.UITypeEditor)), _
           Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.ElementWithCss)> _
           Public Property ImagesList() As DataType.GalleryImages
            Get
                If _imagesList Is Nothing Then
                    _imagesList = New DataType.GalleryImages()
                End If
                Return _imagesList
            End Get
            Set(ByVal value As DataType.GalleryImages)
                _imagesList = value

                Me.CalculateDimImages()

                If BadProportionImg Then
                    OEMsgBox(My.Resources.text.LocalizableFormAndConverter._0200, MsgBoxType.Info, My.Resources.text.LocalizableFormAndConverter._0201)
                End If
                BadProportionImg = False

            End Set
        End Property

        <Browsable(False), _
           Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property ImagesInfo() As List(Of ImagesInfos)
            Get
                If _imagesInfos Is Nothing Then _imagesInfos = New List(Of ImagesInfos)
                Return _imagesInfos
            End Get
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N232"), _
        Ressource.localizable.LocalizableDescAtt("_D232"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.Enum.TConvEnumEasingEffect)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Page)> _
        Public Property Easing() As DataType.Enum.EnumEasingEffect
            Get
                Return _Easing
            End Get
            Set(ByVal value As DataType.Enum.EnumEasingEffect)
                _Easing = value
            End Set
        End Property

        <Browsable(False), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property EasingJs() As String
            Get
                Return _Easing.ToString
            End Get
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

#End Region

#Region "Builder required function"
        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEGalleryCarrousel1", page, parentID, templateName)
            MyBase.NumUpdate = 1
            'Default values
            Me.Sens = EnuCarrousel_HorizontalDirection.GoToLeft
            Me.Vitesse = 1000
            Me._ResizeAllPictures = True
            Me.AutoWaitingTime = 1000
            Me.Easing = [Enum].EnumEasingEffect.none
            DivImageHeight = 100
            DivImageWidth = 550

        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0128
            info.VersionMajor = 2
            info.VersionMinor = 0
            info.GroupName = "NBGroupMedia"
            info.ToolBoxIco = My.Resources.WECarrousel1
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0127
            info.AutoOpenProperty = "ImagesList"
            info.SortPropertyList.Add(New SortProperty("ImagesList", "Tools.png", My.Resources.text.LocalizableOpen._0199))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Images", My.Resources.text.LocalizableOpen._0129, My.Resources.text.LocalizableOpen._0130))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Images", My.Resources.text.LocalizableOpen._0129, My.Resources.text.LocalizableOpen._0130))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Previous", My.Resources.text.LocalizableOpen._0131, My.Resources.text.LocalizableOpen._0132))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Next", My.Resources.text.LocalizableOpen._0133, My.Resources.text.LocalizableOpen._0134))

            MyBase.OnOpen(configStylesZones)

        End Sub

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(Common.EnuScriptType.Css, "ElementsLibrary\Common\Css\WEGalleryCarrousel1.css", "WEFiles/Css/WEGalleryCarrousel1.css")
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEGalleryCarrousel1.js", "WEFiles/Client/WEGalleryCarrousel1.js")
            MyBase.AddSharedScripts(Common.EnuSharedScript.jQueryEasing)
            MyBase.OnInitExternalFiles()
        End Sub

        Protected Overrides Sub OnLoadStyleZones(ByRef configStylesZones As openElement.WebElement.StylesManager.ConfigStylesZone)
            Select Case configStylesZones.Name
                Case "Images"
                    configStylesZones.UIDisabledRibbon.Add(StylesZone.EnuDisabledRibbonType.Margin)
            End Select
            MyBase.OnLoadStyleZones(configStylesZones)
        End Sub

#End Region

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
            For Each Image As GalleryImages.GalleryImageInfo In ImagesList.Images
                Image.UpdateSize = True
            Next

            Me.DivImageHeight = 0 'force the height calculation 
            Me.DivImageWidth = 0 'force the width calculation 
            Call CalculateDimImages() 'calculation at the saving and the preview

            If BadProportionImg Then
                OEMsgBox(My.Resources.text.LocalizableFormAndConverter._0200, MsgBoxType.Info, My.Resources.text.LocalizableFormAndConverter._0201)
            End If
            BadProportionImg = False

            MyBase.OnResizeEnd()
        End Sub

        ''' <summary>
        '''  After the css update, shows if the recalculation of carrousel is necessary
        ''' </summary>
        ''' <param name="zoneName"></param>
        ''' <param name="styleState"></param>
        ''' <param name="styleName"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnCssAfterUpdate(ByVal zoneName As String, ByVal styleState As openElement.WebElement.StylesManager.StylesZone.EnuStyleState, ByVal styleName As openElement.WebElement.Common.CssBase.EnuStyleName)
            If zoneName = "Images" Then
                CssUpdate = True
            End If
            If zoneName = "BaseDiv" Then
                If styleName = Common.CssBase.EnuStyleName.Border _
                    Or styleName = Common.CssBase.EnuStyleName.Margin _
                    Or styleName = Common.CssBase.EnuStyleName.Padding _
                    Or styleName = Common.CssBase.EnuStyleName.Border _
                    Or styleName = Common.CssBase.EnuStyleName.BorderTop _
                    Or styleName = Common.CssBase.EnuStyleName.BorderLeft _
                    Or styleName = Common.CssBase.EnuStyleName.BorderRight _
                    Or styleName = Common.CssBase.EnuStyleName.BorderBottom Then
                    CssUpdate = True
                End If
            End If
            MyBase.OnCssAfterUpdate(zoneName, styleState, styleName)
        End Sub

#Region "DD - Safe model style zone (for 'generic' zones that don't have Carroussel-specific style zones like Images)"

        Private Function GetModelZoneImageSafe() As StylesManager.StylesZone
            Return WEGalleryCarrousel2.GetModelStyleZoneSafe(MyBase.StylesSkin)
        End Function

#End Region

#Region "Forms events"

        Protected Overrides Function OnFrmEditListOfGetFormConfig() As openElement.WebElement.Editors.Control.CtlEditListOf.EditConfig
            Dim addButtonList As New List(Of AddButton)
            addButtonList.Add(New AddButton("AddImage", My.Resources.text.LocalizableFormAndConverter._0203, Nothing)) 
            Dim editConfig As New EditConfig(My.Resources.text.LocalizableFormAndConverter._0113, My.Resources.text.LocalizableFormAndConverter._0170, addButtonList)
            Return editConfig
        End Function

        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As AddButton, ByVal selectedNodeTag As NodeTag) As List(Of Object)

            Dim newObs As New List(Of Object)

            'Add just an image
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

                    Tools.Frm.Wait.RunAction(New ActionWait(AddressOf AddImage), _
                                             New Wait.ActionArg(Of String(), List(Of Object))(fileNames, newObs), _
                                             My.Resources.text.LocalizableFormAndConverter._0128)
                End If

            End If

            Return newObs

        End Function

        Private Sub AddImage(ByVal actionArg As Wait.ActionArg(Of String(), List(Of Object)))
            Dim fileNames As String() = actionArg.Argument1
            Dim newObs As List(Of Object) = actionArg.Argument2

            For Each fullFilePath As String In fileNames
                Dim image As New GalleryImages.GalleryImageInfo(Me, fullFilePath, ImagesList.GalleryForderLink, Me.Page.Culture)
                newObs.Add(image)
                Windows.Forms.Application.DoEvents()
            Next
        End Sub

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

#End Region


#Region "Render"

        Protected Overrides Sub OnPageBeforeRender(ByVal mode As Page.EnuTypeRenderMode)
            ' we must recalculate the size if the css (border,margin,padding) has been modified
            If Me.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Export AndAlso CssUpdate Then

                For Each Image As GalleryImages.GalleryImageInfo In ImagesList.Images
                    Image.UpdateSize = True
                Next

                Me.DivImageHeight = 0 'Force the height calculation
                Me.DivImageWidth = 0 'Force the width calculation

                Call CalculateDimImages()

                CssUpdate = False
            End If

            MyBase.OnPageBeforeRender(mode)
        End Sub

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter) 'Private Sub RenderExportMode(ByRef writer As Common.HtmlWriter)
            MyBase.RenderBeginTag(writer)

            'Les buttons next and prev
            'If Me.Auto = False Then
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Previous"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()
            'End If

            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "WECarrousel1Parent")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.Indent += 1
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "WECarrousel1ImagesParent")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()
            writer.Indent += 1

            If MyBase.Page.RenderMode <> openElement.WebElement.Page.EnuTypeRenderMode.Export Then

                writer.WriteBeginTag("table")
                writer.WriteAttribute("style", "width:100%;height:100%;background-color:#999999;")
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                writer.WriteFullBeginTag("tr")
                writer.WriteBeginTag("td")
                writer.WriteAttribute("style", "text-align:center;vertical-align:middle")
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                writer.WriteBeginTag("div")
                writer.WriteAttribute("style", "color:#FFFFF;font-size :10px;font-family :Arial;white-space:normal; word-wrap:false;")
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.Write(My.Resources.text.LocalizablePropertyDefaultValue._0015)
                writer.WriteEndTag("div")

                writer.WriteEndTag("td")
                writer.WriteEndTag("tr")
                writer.WriteEndTag("table")

            Else
                If _NbImage <> 0 Then
                    Dim TotalImgW As Integer = 0
                    For i As Integer = 0 To _NbImage - 1
                        TotalImgW += ImagesInfo(i).ImgOuterWidth
                    Next
                    Dim MT As Integer = (Me.DivImageWidth - TotalImgW) / (Me._NbImage + 1)
                    If MT < 0 Then MT = 0 'if the image is too large

                    Dim oldPosition = 0
                    Dim oldWidth = 0
                    Dim LeftPosition = MT + oldPosition + oldWidth

                    For i As Integer = 0 To _NbImage - 1
                        LeftPosition = MT + oldPosition + oldWidth
                        oldPosition = LeftPosition
                        oldWidth = ImagesInfo(i).ImgOuterWidth

                        Dim PageLink As String = MyBase.GetLink(ImagesInfo(i).PageLink, Me.Page.Culture)
                        Dim ImgPath As String = MyBase.GetLink(ImagesInfo(i).ImgURL, Me.Page.Culture)

                        If String.IsNullOrEmpty(ImgPath) Then
                            ImgPath = MyBase.GetLink(ImagesInfo(i).ImageOriginURL, Me.Page.Culture)
                        End If

                        writer.WriteBeginTag("div")
                        writer.WriteAttribute("class", "CarrouselH_Img")
                        writer.WriteAttribute("style", String.Concat("height:", ImagesInfo(i).ImgHeight.ToString, "px ; width:" & ImagesInfo(i).ImgWidth.ToString & "px; left:", LeftPosition.ToString, "px;"))
                        writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                        'specific html code of image
                        If Not String.IsNullOrEmpty(PageLink) Then
                            writer.WriteBeginTag("a")
                            writer.WriteHrefAttribute(Me, ImagesInfo(i).PageLink, True)
                            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                        End If

                        writer.WriteBeginTag("img")
                        Dim Desc As String = ImagesList.Images(i).Comment.GetValue(MyBase.Page.Culture)
                        If Desc.Length > 50 Then Desc = Desc.Remove(0, 50)
                        writer.WriteAttribute("alt", Desc)
                        writer.WriteAttribute("src", ImgPath)
                        writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Images"))
                        Dim title As String = ImagesInfo(i).Title.GetValue(MyBase.Page.Culture)
                        If Not String.IsNullOrEmpty(title) Then writer.WriteAttribute("title", title)

                        writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd) ' />

                        If Not String.IsNullOrEmpty(PageLink) Then writer.WriteEndTag("a")

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
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()


            MyBase.RenderEndTag(writer)

        End Sub


#End Region

#Region "Caculation of images"

        ''' <summary>
        ''' Image resized at the specific height (Priority: vertical) 
        ''' </summary>
        ''' <param name="newImageHeigth"></param>
        ''' <remarks></remarks>
        Private Sub ResizeImage(ByVal newImageHeigth As Integer)
            If Me.ImagesList.Images.Count = 0 Then Exit Sub

            Dim resizeConfig As openElement.Tools.Picture.PictureResizeConfig = New openElement.Tools.Picture.PictureResizeConfig(New Size(newImageHeigth, newImageHeigth), Tools.Enu.EnuPriorityImageResize.Vertical, False, False)
            Me.ImagesList.Resize(Me, resizeConfig, Nothing, Nothing, _ResizeAllPictures)
            _ResizeAllPictures = False

        End Sub

        ''' <summary>
        ''' calculation or recalculation the dimentions of the images of the carrousel according to its height or of style zone's parameters
        ''' Be carefull! this calculation is on the all carrousel's images
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CalculateDimImages()

            'Images style zone (BE CAREFULL! it's not the first div around of images)  
            Dim ImagesZone As StylesManager.StylesZone = MyBase.StylesSkin.FindStylesZone("Images")
            Dim modelSkin_ImagesZone As StylesManager.StylesZone = GetModelZoneImageSafe()

            Dim PaddingBorderWidth As Integer = Me.OuterPBWidth(ImagesZone, modelSkin_ImagesZone) 'must be used for the dimensions calculation  of the images
            Dim MarginWidth As Integer = Me.OuterMarginWidth(ImagesZone, modelSkin_ImagesZone)   'must be used for the numbers images calculation

            'calculation of width margin starting from this height > to imagesInfo
            'we use also the padding and the border of image
            Call SearchDimImage(PaddingBorderWidth)

            'we must find the initial images number(initial first last last index find by js)
            Dim BaseWidth As Integer = 0
            _NbImage = 0

            For Each Image As ImagesInfos In Me.ImagesInfo
                BaseWidth = BaseWidth + (Image.ImgOuterWidth + MarginWidth)
                If BaseWidth < Me.DivImageWidth Then _NbImage = _NbImage + 1 Else Exit For
            Next

            If Me.ImagesInfo.Count <> 0 AndAlso _NbImage = 0 Then
                'special case where the first image is greater of the carrousel's width
                _NbImage = 1
            End If

        End Sub

#Region "fast calculation functions"

        ''' <summary>
        ''' search outer dimension for the styleZone
        ''' </summary>
        ''' <param name="styleZone"></param>
        ''' <param name="withParent">true if we include the parent's padding</param>
        ''' <returns></returns>
        ''' <remarks>no margin because the position is 'absolute'  ONLY PADDING ET BORDER</remarks>
        Private Function OuterHeight(ByVal styleZone As StylesManager.StylesZone, ByVal modelStyleZone As StylesManager.StylesZone, ByVal withParent As Boolean) As Integer
            Dim outer As Integer = 0

            If withParent Then
                Dim ParentStyle As StylesManager.Styles = MyBase.StylesSkin.BaseDiv.BaseStyles
                Dim modelBase As StylesManager.Styles = MyBase.StylesSkin.StylesSkinModel.BaseDiv.BaseStyles

                Dim ParentBorderValue As Integer = 0
                Dim ParentBorderTopValue As Integer = 0
                Dim ParentborderBottomValue As Integer = 0
                Dim ParentPaddingTopValue As Integer = 0
                Dim ParentPaddingBottomValue As Integer = 0

                'parent's PADDING 
                If Not String.IsNullOrEmpty(ParentStyle.Padding.Top.Value) Then Integer.TryParse(ParentStyle.Padding.Top.Value, ParentPaddingTopValue) Else _
                    If Not String.IsNullOrEmpty(modelBase.Padding.Top.Value) Then Integer.TryParse(modelBase.Padding.Top.Value, ParentPaddingTopValue)
                If Not String.IsNullOrEmpty(ParentStyle.Padding.Bottom.Value) Then Integer.TryParse(ParentStyle.Padding.Bottom.Value, ParentPaddingBottomValue) Else _
                    If Not String.IsNullOrEmpty(modelBase.Padding.Bottom.Value) Then Integer.TryParse(modelBase.Padding.Bottom.Value, ParentPaddingTopValue)
                'parent's BORDER 
                If Not String.IsNullOrEmpty(ParentStyle.Border.Width.Value) AndAlso ParentStyle.Border.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(ParentStyle.Border.Width.Value, ParentBorderValue) Else _
                    If Not String.IsNullOrEmpty(modelBase.Border.Width.Value) AndAlso modelBase.Border.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(modelBase.Border.Width.Value, ParentBorderValue)
                If Not String.IsNullOrEmpty(ParentStyle.BorderTop.Width.Value) AndAlso ParentStyle.BorderTop.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(ParentStyle.BorderTop.Width.Value, ParentBorderTopValue) Else _
                    If Not String.IsNullOrEmpty(modelBase.BorderTop.Width.Value) AndAlso modelBase.BorderTop.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(modelBase.BorderTop.Width.Value, ParentBorderTopValue)
                If Not String.IsNullOrEmpty(ParentStyle.BorderBottom.Width.Value) AndAlso ParentStyle.BorderBottom.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(ParentStyle.BorderBottom.Width.Value, ParentborderBottomValue) Else _
                    If Not String.IsNullOrEmpty(modelBase.BorderBottom.Width.Value) AndAlso modelBase.BorderBottom.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(modelBase.BorderBottom.Width.Value, ParentborderBottomValue)

                If ParentBorderTopValue <> 0 Then outer += ParentBorderTopValue Else outer += ParentBorderValue
                If ParentborderBottomValue <> 0 Then outer += ParentborderBottomValue Else outer += ParentBorderValue

                outer += ParentPaddingBottomValue + ParentPaddingTopValue

            End If

            Dim BorderValue As Integer = 0
            Dim BorderTopValue As Integer = 0
            Dim borderBottomValue As Integer = 0
            Dim PaddingTopValue As Integer = 0
            Dim paddingBottomValue As Integer = 0
            Dim MarginTopValue As Integer = 0
            Dim MarginBottomValue As Integer = 0
            'element's PADDING 
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Padding.Top.Value) Then Integer.TryParse(styleZone.BaseStyles.Padding.Top.Value, PaddingTopValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Padding.Top.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Padding.Top.Value, PaddingTopValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Padding.Bottom.Value) Then Integer.TryParse(styleZone.BaseStyles.Padding.Bottom.Value, paddingBottomValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Padding.Bottom.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Padding.Bottom.Value, paddingBottomValue)
            'element's MARGIN  
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Margin.Top.Value) Then Integer.TryParse(styleZone.BaseStyles.Margin.Top.Value, MarginTopValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Margin.Top.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Margin.Top.Value, MarginTopValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Margin.Bottom.Value) Then Integer.TryParse(styleZone.BaseStyles.Margin.Bottom.Value, MarginBottomValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Margin.Bottom.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Margin.Bottom.Value, MarginBottomValue)
            'element's BORDER  
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Border.Width.Value) AndAlso styleZone.BaseStyles.Border.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.Border.Width.Value, BorderValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Border.Width.Value) AndAlso modelStyleZone.BaseStyles.Border.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.Border.Width.Value, BorderValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.BorderTop.Width.Value) AndAlso styleZone.BaseStyles.BorderTop.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.BorderTop.Width.Value, BorderTopValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.BorderTop.Width.Value) AndAlso modelStyleZone.BaseStyles.BorderTop.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.BorderTop.Width.Value, BorderTopValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.BorderBottom.Width.Value) AndAlso styleZone.BaseStyles.BorderBottom.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.BorderBottom.Width.Value, borderBottomValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.BorderBottom.Width.Value) AndAlso modelStyleZone.BaseStyles.BorderBottom.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.BorderBottom.Width.Value, borderBottomValue)

            If BorderTopValue <> 0 Then outer += BorderTopValue Else outer += BorderValue
            If borderBottomValue <> 0 Then outer += borderBottomValue Else outer += BorderValue

            outer += PaddingTopValue + paddingBottomValue + MarginTopValue + MarginBottomValue

            Return outer
        End Function

        ''' <summary>
        ''' search the added dimension  (inside :padding and border)
        ''' </summary>
        ''' <param name="styleZone"></param>
        ''' <param name="modelStyleZone"></param>
        ''' <returns></returns>
        ''' <remarks>Only Padding et Border</remarks>
        Private Function OuterPBWidth(ByVal styleZone As StylesManager.StylesZone, ByVal modelStyleZone As StylesManager.StylesZone) As Integer
            If styleZone Is Nothing OrElse modelStyleZone Is Nothing Then Return 0

            Dim inner As Integer = 0

            Dim BorderValue As Integer = 0
            Dim BorderLeftValue As Integer = 0
            Dim borderRightValue As Integer = 0
            Dim PaddingLeftValue As Integer = 0
            Dim PaddingRightValue As Integer = 0

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Padding.Left.Value) Then Integer.TryParse(styleZone.BaseStyles.Padding.Left.Value, PaddingLeftValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Padding.Left.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Padding.Left.Value, PaddingLeftValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Padding.Right.Value) Then Integer.TryParse(styleZone.BaseStyles.Padding.Right.Value, PaddingRightValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Padding.Right.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Padding.Right.Value, PaddingRightValue)

            'special cas of border : used only if the style is known. (border-left and border-right on border priority)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Border.Width.Value) AndAlso styleZone.BaseStyles.Border.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.Border.Width.Value, BorderValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Border.Width.Value) AndAlso modelStyleZone.BaseStyles.Border.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.Border.Width.Value, BorderValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.BorderLeft.Width.Value) AndAlso styleZone.BaseStyles.BorderLeft.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.BorderLeft.Width.Value, BorderLeftValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.BorderLeft.Width.Value) AndAlso modelStyleZone.BaseStyles.BorderLeft.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.BorderLeft.Width.Value, BorderLeftValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.BorderRight.Width.Value) AndAlso styleZone.BaseStyles.BorderRight.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.BorderRight.Width.Value, borderRightValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.BorderRight.Width.Value) AndAlso modelStyleZone.BaseStyles.BorderRight.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.BorderRight.Width.Value, borderRightValue)

            If BorderLeftValue <> 0 Then inner += BorderLeftValue Else inner += BorderValue
            If borderRightValue <> 0 Then inner += borderRightValue Else inner += BorderValue

            inner += PaddingLeftValue + PaddingRightValue

            Return inner

        End Function

        ''' <summary>
        ''' research for the style zone of the margin-left and margin-right
        ''' </summary>
        ''' <param name="styleZone"></param>
        ''' <returns></returns>
        ''' <remarks>no use the parent's div and ONLY MARGIN</remarks>
        Private Function OuterMarginWidth(ByVal styleZone As StylesManager.StylesZone, ByVal modelStyleZone As StylesManager.StylesZone) As Integer
            If styleZone Is Nothing OrElse modelStyleZone Is Nothing Then Return 0

            Dim outer As Integer = 0

            Dim MarginLeftValue As Integer = 0
            Dim MarginRightValue As Integer = 0

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Margin.Left.Value) Then Integer.TryParse(styleZone.BaseStyles.Margin.Left.Value, MarginLeftValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Margin.Left.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Margin.Left.Value, MarginLeftValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Margin.Right.Value) Then Integer.TryParse(styleZone.BaseStyles.Margin.Right.Value, MarginRightValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Margin.Right.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Margin.Right.Value, MarginRightValue)

            outer += MarginLeftValue + MarginRightValue
            Return outer
        End Function

#End Region

        Private Sub Calculate_DivImageWidth()

            If Not String.IsNullOrEmpty(MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value) _
                AndAlso IsNumeric(MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value) Then
                DivImageWidth = Integer.Parse(MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value)
                Exit Sub
            End If

            Dim modelSkin As StylesManager.StylesZone = GetModelZoneImageSafe()

            'style model if the element's value is none
            If Not String.IsNullOrEmpty(modelSkin.BaseStyles.Width.Value) AndAlso IsNumeric(modelSkin.BaseStyles.Width.Value) Then DivImageWidth = Integer.Parse(modelSkin.BaseStyles.Width.Value)

        End Sub

        Private Sub Calculate_ImagesHeigth(ByVal imagesZone As StylesManager.StylesZone, ByVal modelSkin_ImagesZone As StylesManager.StylesZone)

            ' special case where we are no image's height  
            If Not String.IsNullOrEmpty(imagesZone.BaseStyles.Height.Value) AndAlso IsNumeric(imagesZone.BaseStyles.Height.Value) Then
                _DivImageHeight2 = Integer.Parse(imagesZone.BaseStyles.Height.Value)
            Else
                Dim modelSkin As StylesManager.StylesZone = GetModelZoneImageSafe()
                Dim modelHeight As String = modelSkin.BaseStyles.Height.Value
                If Not String.IsNullOrEmpty(modelHeight) AndAlso IsNumeric(modelHeight) Then _DivImageHeight2 = Integer.Parse(modelHeight) : Exit Sub

                Dim BaseDivHeigthValue As String = MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Value
                If Not String.IsNullOrEmpty(BaseDivHeigthValue) AndAlso IsNumeric(BaseDivHeigthValue) Then _DivImageHeight2 = Integer.Parse(BaseDivHeigthValue)

                Dim outer_Height As Integer = Me.OuterHeight(imagesZone, modelSkin_ImagesZone, True)
                If outer_Height <> 0 Then _DivImageHeight2 = _DivImageHeight2 - outer_Height
            End If

        End Sub

        Private Sub SearchDimImage(ByVal innerWidth As Integer)
            If ImagesList.Images.Count = 0 Then Exit Sub

            Dim newImagesInfo = New List(Of ImagesInfos)

            For Each Image In Me.ImagesList.Images
                Dim ThisImageWidth As Integer = Image.LinkSize1.ImageSize.Width
                Dim ThisImageHeight As Integer = DivImageHeight

                Dim ResizeLink As LinksManager.Link

                Dim OriginImageWidth = Image.LinkOrigin.ImageSize.Width
                Dim OriginImageHeigth = Image.LinkOrigin.ImageSize.Height

                If OriginImageWidth = 0 OrElse OriginImageHeigth = 0 Then
                    'we open the image
                    Dim filePath As String = MyBase.GetLinkIOPath(Image.LinkOrigin, MyBase.Page.Culture)
                    Dim img As OBitmap = MyBase.OpenBitmap(filePath)
                    If img Is Nothing Then
                        OEMsgBox(My.Resources.text.LocalizableFormAndConverter._0154 & vbCrLf & filePath, MsgBoxType.Err, My.Resources.text.LocalizableFormAndConverter._0155)
                        MyBase.CloseBitmap(img)
                        Continue For 'we can't open the image  
                    End If
                    OriginImageHeigth = img.Height
                    OriginImageWidth = img.Width
                    If OriginImageWidth = 0 OrElse OriginImageHeigth = 0 Then
                        OEMsgBox(My.Resources.text.LocalizableFormAndConverter._0154 & vbCrLf & filePath, MsgBoxType.Err, My.Resources.text.LocalizableFormAndConverter._0155)
                        MyBase.CloseBitmap(img)
                        Continue For 'we can't open the image  
                    End If
                    MyBase.CloseBitmap(img)
                End If

                'Proportional calculation
                ThisImageWidth = (ThisImageHeight * OriginImageWidth) / (OriginImageHeigth)

                'special case where height/width isn't compatible with the images
                If ThisImageWidth > DivImageWidth Then
                    'we must recalculate the size
                    ThisImageWidth = DivImageWidth
                    ThisImageHeight = (ThisImageWidth * OriginImageHeigth) / (OriginImageWidth)
                    BadProportionImg = True
                End If

                If ThisImageWidth = 0 OrElse Image.UpdateSize = True Then
                    'not automatic resizing ! we take the images's source
                    ResizeLink = Image.LinkOrigin
                Else
                    ResizeLink = Image.LinkSize1
                End If

                newImagesInfo.Add(New ImagesInfos(ResizeLink, Image.LinkOrigin, Image.PageLink, ThisImageHeight, 0, ThisImageWidth, ThisImageWidth + innerWidth, Image.Title))
                Dim linkimage As String = ResizeLink.GetIOPath
            Next

            Me._imagesInfos = newImagesInfo

        End Sub

#End Region

    End Class
End Namespace
