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
    ''' <summary>
    ''' VERTICAL Carrousel 
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class WEGalleryCarrousel2
        Inherits ElementBase

#Region "properties"


        <Common.Attributes.ContainsLinks()> _
        Private _imagesList As DataType.GalleryImages
        ''' <summary>
        ''' Config class write in the js file
        ''' </summary>
        ''' <remarks></remarks>
        Private _imagesInfo As List(Of ImagesInfos)

        <NonSerialized()> Private _CssUpdate As Boolean

        Private BadProportionImg As Boolean = False

#Region "Behavior specific variable (user config)"

        Private _Sens As EnuCarrousel_VerticalDirection
        Private _infinite As Boolean
        Private _decalage As Integer
        Private _autoWaitingTime As Integer
        Private _auto As Boolean
        Private _vitesse As Integer
       Private _TypeEffect As EnuCarrousel_TypeEffect

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.settings), _
          Ressource.localizable.LocalizableNameAtt("_N117"), _
          Ressource.localizable.LocalizableDescAtt("_D117"), _
          TypeConverter(GetType(Editors.Converter.TConvEnuCarrousel_VerticalDirection)), _
          Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js), _
          Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
     Public Property Sens() As EnuCarrousel_VerticalDirection
            Get
                Return _Sens
            End Get
            Set(ByVal value As EnuCarrousel_VerticalDirection)
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

        ''' <summary>
        ''' width of div containing carrousel's images 
        ''' </summary>
        ''' <remarks></remarks>
        <NonSerialized()> Private _DivImageWidth2 As Integer
        ''' <summary>
        ''' height of div containing carrousel's images 
        ''' </summary>
        ''' <remarks></remarks>
        <NonSerialized()> Private _DivImageHeight2 As Integer


        ''' <summary>
        ''' display image's number at the first page load
        ''' </summary>
        ''' <remarks></remarks>
        Private _NbImage As Integer

        ''' <summary>
        ''' slowing effect  
        ''' </summary>
        ''' <remarks></remarks>
        Private _Easing As DataType.Enum.EnumEasingEffect
        <NonSerialized()> Private _EasingJS As String

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

                'we must recalculate the sizes of images 
                Me.CalculateDimImages()

                If BadProportionImg Then
                    OEMsgBox(My.Resources.text.LocalizableFormAndConverter._0200, MsgBoxType.Info, My.Resources.text.LocalizableFormAndConverter._0201)
                End If
                BadProportionImg = False

            End Set
        End Property

        ''' <summary>
        ''' Write in js file : contains the images's source path and the margins to apply 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False), _
           Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property ImagesInfo() As List(Of ImagesInfos)
            Get
                If _imagesInfo Is Nothing Then _imagesInfo = New List(Of ImagesInfos)
                Return _imagesInfo
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

        ''' <summary>
        ''' export the visual effect in js file
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Js)> _
        Public ReadOnly Property EasingJs() As String
            Get
                Return _Easing.ToString
            End Get
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

#End Region

#Region "DD - Safe model style zone (for 'generic' zones that don't have Carroussel-specific style zones like Images)"

        Friend Shared Function GetModelStyleZoneSafe(ByVal styleSkin As StylesSkin, Optional ByVal name As String = "Images") As StylesManager.StylesZone
            If styleSkin Is Nothing Then Return Nothing
            Dim styleSkinModel As StylesSkinModel = styleSkin.StylesSkinModel : If styleSkinModel Is Nothing Then Return Nothing ' skin coming from model

            Dim r As StylesManager.StylesZone = styleSkinModel.FindStylesZone(name)
            If r Is Nothing Then r = styleSkin.FindStylesZone(name) ' if zone is missing from model, take it from element's skin
            Return r
        End Function

        Private Function GetModelZoneImageSafe() As StylesManager.StylesZone
            Return GetModelStyleZoneSafe(MyBase.StylesSkin)
        End Function

#End Region

#Region "Builder required function"
        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEGalleryCarrousel2", page, parentID, templateName)
            MyBase.NumUpdate = 1
            'default value
            Me.Sens = EnuCarrousel_VerticalDirection.GoToBottom
            Me.Vitesse = 1000
            Me._ResizeAllPictures = True
            Me.AutoWaitingTime = 1000
            Me.Easing = [Enum].EnumEasingEffect.none
            DivImageHeight = 500
            DivImageWidth = 150
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0312
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupMedia"
            info.ToolBoxIco = My.Resources.WECarrousel2
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0313
            info.AutoOpenProperty = "ImagesList"
            info.SortPropertyList.Add(New SortProperty("ImagesList", "Tools.png", My.Resources.text.LocalizableOpen._0199))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim ConfigStylesZones As New List(Of StylesManager.ConfigStylesZone)
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Images", My.Resources.text.LocalizableOpen._0129, My.Resources.text.LocalizableOpen._0130))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Next", My.Resources.text.LocalizableOpen._0131, My.Resources.text.LocalizableOpen._0132))
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Previous", My.Resources.text.LocalizableOpen._0133, My.Resources.text.LocalizableOpen._0134))

            MyBase.OnOpen(ConfigStylesZones)

        End Sub

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(Common.EnuScriptType.Css, "ElementsLibrary\Common\Css\WEGalleryCarrousel2.css", "WEFiles/Css/WEGalleryCarrousel2.css")
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEGalleryCarrousel2.js", "WEFiles/Client/WEGalleryCarrousel2.js")
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

        Protected Overrides Sub OnPageInit()
            If MyBase.NumUpdate = 0 Then
                'we must recalculate the sizes, the images number and the width of arround div
                _ResizeAllPictures = True
                For Each Image As GalleryImages.GalleryImageInfo In ImagesList.Images
                    Image.UpdateSize = True
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

        ''' <summary>
        ''' After the css update, shows if the recalculation of carrousel's images is necessary
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

#Region "Forms events"
       
        Protected Overrides Function OnFrmEditListOfGetFormConfig() As openElement.WebElement.Editors.Control.CtlEditListOf.EditConfig
            Dim AddButtonList As New List(Of AddButton)
            AddButtonList.Add(New AddButton("AddImage", My.Resources.text.LocalizableFormAndConverter._0203, Nothing)) 
            Dim EditConfig As New EditConfig(My.Resources.text.LocalizableFormAndConverter._0113, My.Resources.text.LocalizableFormAndConverter._0170, AddButtonList)
            Return EditConfig
        End Function

        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal addButton As AddButton, ByVal selectedNodeTag As NodeTag) As List(Of Object)

            Dim NewObs As New List(Of Object)

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
                                         New Wait.ActionArg(Of String(), List(Of Object))(fileNames, NewObs), _
                                         My.Resources.text.LocalizableFormAndConverter._0128)

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
            Return NewObs

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
                Me.DivImageHeight = 0 'Force the height calculation
                Me.DivImageWidth = 0 'Force the width calculation
                Call CalculateDimImages()
                CssUpdate = False
            End If

            MyBase.OnPageBeforeRender(mode)
        End Sub

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter) 'Private Sub RenderExportMode(ByRef writer As Common.HtmlWriter)
            MyBase.RenderBeginTag(writer)

            
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Previous"))
            writer.WriteAttribute("style", "position:absolute")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()


            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "WECarrousel2Parent")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteLine()

            writer.Indent += 1
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "WECarrousel2ImagesParent")
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
                    Dim TotalImgH As Integer = 0
                    For i As Integer = 0 To _NbImage - 1
                        TotalImgH += ImagesInfo(i).ImgOuterHeight
                    Next
                    Dim MT As Integer = (Me.DivImageHeight - TotalImgH) / (Me._NbImage + 1)
                    If MT < 0 Then MT = 0 'if the image is too large 

                    Dim oldPosition = 0
                    Dim oldheight = 0
                    Dim TopPosition = MT + oldPosition + oldheight

                    For i As Integer = 0 To _NbImage - 1
                        TopPosition = MT + oldPosition + oldheight
                        oldPosition = TopPosition
                        oldheight = ImagesInfo(i).ImgOuterHeight

                        Dim PageLink As String = MyBase.GetLink(ImagesInfo(i).PageLink, Me.Page.Culture)
                        Dim ImgPath As String = MyBase.GetLink(ImagesInfo(i).ImgURL, Me.Page.Culture)

                        If String.IsNullOrEmpty(ImgPath) Then
                            ImgPath = MyBase.GetLink(ImagesInfo(i).ImageOriginURL, Me.Page.Culture)
                        End If

                        writer.WriteBeginTag("div")
                        writer.WriteAttribute("class", "CarrouselV_Img")
                        writer.WriteAttribute("style", String.Concat("width:", ImagesInfo(i).ImgWidth.ToString, "px ; height:", ImagesInfo(i).ImgHeight.ToString, "px ; top:", TopPosition.ToString, "px;"))
                        writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                        'image html code
                        If Not String.IsNullOrEmpty(PageLink) Then
                            writer.WriteBeginTag("a")
                            writer.WriteHrefAttribute(Me, ImagesInfo(i).PageLink, True)
                            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                        End If

                        writer.WriteBeginTag("img")
                        '03/19 update > the description is used for the alt tag
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
            writer.WriteAttribute("style", "position:absolute")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteLine()


            MyBase.RenderEndTag(writer)

        End Sub

#End Region

#Region "Caculation of images"

        ''' <summary>
        '''  Image resized at the specific height (Priority: vertical) 
        ''' </summary>
        ''' <param name="newImageWidth"></param>
        ''' <remarks></remarks>
        Private Sub ResizeImage(ByVal newImageWidth As Integer)
            If Me.ImagesList.Images.Count = 0 Then Exit Sub 'no action

            Dim resizeConfig As openElement.Tools.Picture.PictureResizeConfig = New openElement.Tools.Picture.PictureResizeConfig(New Size(newImageWidth, newImageWidth), Tools.Enu.EnuPriorityImageResize.Horizontal, False, False)
            Me.ImagesList.Resize(Me, resizeConfig, Nothing, Nothing, _ResizeAllPictures)
            _ResizeAllPictures = False

        End Sub

        Protected Overrides Sub OnResizeEnd()
            'force the resizing of images and margins
            _ResizeAllPictures = True
            For Each Image As GalleryImages.GalleryImageInfo In ImagesList.Images
                Image.UpdateSize = True
            Next

            'we must recalculation the height, images number and the div around width
            Me.DivImageWidth = 0 'force the Width calculation 
            Me.DivImageHeight = 0 'force the height calculation 
            Call CalculateDimImages()

            MyBase.OnResizeEnd()

            If BadProportionImg Then
                OEMsgBox(My.Resources.text.LocalizableFormAndConverter._0200, MsgBoxType.Info, My.Resources.text.LocalizableFormAndConverter._0201) 'Certaines images n'étant pas proportionnel aux dimensions du carrousel, elles  seront  redimensionnées pour s'afficher correctement.
            End If
            BadProportionImg = False
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
            Dim innerHeight As Integer = Me.OuterPBHeight(ImagesZone, modelSkin_ImagesZone) 'must be used for the dimensions calculation  of the images
            Dim outerHeight As Integer = Me.OuterMarginHeight(ImagesZone, modelSkin_ImagesZone)    'must be used for the numbers images calculation

            'calculation of width margin starting from this height > to imagesInfo
            'we use also the padding and the border of image
            Call SearchDimImage(ImagesZone, innerHeight)

            'we must find the initial images number(initial first last last index find by js))
            Dim baseHeight As Integer = 0
            _NbImage = 0

            For Each Image As ImagesInfos In Me.ImagesInfo
                baseHeight = baseHeight + (Image.ImgOuterHeight + outerHeight)
                If baseHeight < Me.DivImageHeight Then _NbImage = _NbImage + 1 Else Exit For
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
        ''' <remarks></remarks>
        Private Function Outer_width(ByVal styleZone As StylesManager.StylesZone, ByVal modelStyleZone As StylesManager.StylesZone, ByVal withParent As Boolean) As Integer
            Dim outer As Integer = 0

            If withParent Then
                Dim BaseStyles As StylesManager.Styles = MyBase.StylesSkin.BaseDiv.BaseStyles
                Dim ModelBaseStyles As StylesManager.Styles = MyBase.StylesSkin.StylesSkinModel.BaseDiv.BaseStyles

                Dim ParentPaddingLeftValue As Integer = 0
                Dim ParentPaddingRightValue As Integer = 0
                Dim ParentBorderValue As Integer = 0
                Dim ParentBorderleftValue As Integer = 0
                Dim ParentborderRightValue As Integer = 0

                'parent's PADDING 
                If Not String.IsNullOrEmpty(BaseStyles.Padding.Left.Value) Then Integer.TryParse(BaseStyles.Padding.Left.Value, ParentPaddingLeftValue) Else _
                    If Not String.IsNullOrEmpty(ModelBaseStyles.Padding.Left.Value) Then Integer.TryParse(ModelBaseStyles.Padding.Left.Value, ParentPaddingLeftValue)
                If Not String.IsNullOrEmpty(BaseStyles.Padding.Right.Value) Then Integer.TryParse(BaseStyles.Padding.Right.Value, ParentPaddingRightValue) Else _
                    If Not String.IsNullOrEmpty(ModelBaseStyles.Padding.Right.Value) Then Integer.TryParse(ModelBaseStyles.Padding.Right.Value, ParentPaddingRightValue)
                'parent's BORDER
                If Not String.IsNullOrEmpty(BaseStyles.Border.Width.Value) AndAlso BaseStyles.Border.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then ParentBorderValue = Integer.Parse(BaseStyles.Border.Width.Value) Else _
                    If Not String.IsNullOrEmpty(ModelBaseStyles.Border.Width.Value) AndAlso ModelBaseStyles.Border.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then ParentBorderValue = Integer.Parse(ModelBaseStyles.Border.Width.Value)
                If Not String.IsNullOrEmpty(BaseStyles.BorderLeft.Width.Value) AndAlso BaseStyles.BorderLeft.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then ParentBorderleftValue = Integer.Parse(BaseStyles.BorderLeft.Width.Value) Else _
                    If Not String.IsNullOrEmpty(ModelBaseStyles.BorderLeft.Width.Value) AndAlso ModelBaseStyles.BorderLeft.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then ParentBorderleftValue = Integer.Parse(ModelBaseStyles.BorderLeft.Width.Value)
                If Not String.IsNullOrEmpty(BaseStyles.BorderRight.Width.Value) AndAlso BaseStyles.BorderRight.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then ParentborderRightValue = Integer.Parse(BaseStyles.BorderRight.Width.Value) Else _
                    If Not String.IsNullOrEmpty(ModelBaseStyles.BorderRight.Width.Value) AndAlso ModelBaseStyles.BorderRight.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then ParentborderRightValue = Integer.Parse(ModelBaseStyles.BorderRight.Width.Value)

                If ParentBorderleftValue <> 0 Then outer += ParentBorderleftValue Else outer += ParentBorderValue
                If ParentborderRightValue <> 0 Then outer += ParentborderRightValue Else outer += ParentBorderValue

                outer += ParentPaddingLeftValue + ParentborderRightValue

            End If

            Dim paddingLeftValue As Integer = 0
            Dim paddingRightValue As Integer = 0
            Dim MarginLeftValue As Integer = 0
            Dim MarginRightValue As Integer = 0

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Padding.Left.Value) Then Integer.TryParse(styleZone.BaseStyles.Padding.Left.Value, paddingLeftValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Padding.Left.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Padding.Left.Value, paddingLeftValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Padding.Right.Value) Then Integer.TryParse(styleZone.BaseStyles.Padding.Right.Value, paddingRightValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Padding.Right.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Padding.Right.Value, paddingRightValue)

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Margin.Left.Value) Then Integer.TryParse(styleZone.BaseStyles.Margin.Left.Value, MarginLeftValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Margin.Left.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Margin.Left.Value, MarginLeftValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Margin.Right.Value) Then Integer.TryParse(styleZone.BaseStyles.Margin.Right.Value, MarginRightValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Margin.Right.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Margin.Right.Value, MarginRightValue)

            Dim BorderValue As Integer = 0
            Dim BorderLeftValue As Integer = 0
            Dim borderRightValue As Integer = 0

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Border.Width.Value) AndAlso styleZone.BaseStyles.Border.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.Border.Width.Value, BorderValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Border.Width.Value) AndAlso modelStyleZone.BaseStyles.Border.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.Border.Width.Value, BorderValue)

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.BorderLeft.Width.Value) AndAlso styleZone.BaseStyles.BorderLeft.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.BorderLeft.Width.Value, BorderLeftValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.BorderLeft.Width.Value) AndAlso modelStyleZone.BaseStyles.BorderLeft.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.BorderLeft.Width.Value, BorderLeftValue)

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.BorderRight.Width.Value) AndAlso styleZone.BaseStyles.BorderRight.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.BorderRight.Width.Value, borderRightValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.BorderRight.Width.Value) AndAlso modelStyleZone.BaseStyles.BorderRight.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.BorderRight.Width.Value, borderRightValue)

            If BorderLeftValue <> 0 Then outer += BorderLeftValue Else outer += BorderValue
            If borderRightValue <> 0 Then outer += borderRightValue Else outer += BorderValue

            outer += paddingLeftValue + paddingRightValue + MarginLeftValue + MarginRightValue

            Return outer
        End Function

        ''' <summary>
        ''' search the added dimension  (inside :padding and border)
        ''' </summary>
        ''' <param name="styleZone"></param>
        ''' <param name="modelStyleZone"></param>
        ''' <returns></returns>
        ''' <remarks>ONLY BORDER AND PADDING</remarks>
        Private Function OuterPBHeight(ByVal styleZone As StylesManager.StylesZone, ByVal modelStyleZone As StylesManager.StylesZone) As Integer
            If styleZone Is Nothing OrElse modelStyleZone Is Nothing Then Return 0

            Dim inner As Integer = 0

            Dim PaddingTopValue As Integer = 0
            Dim PaddingBottomValue As Integer = 0
            Dim BorderValue As Integer = 0
            Dim BorderTopValue As Integer = 0
            Dim borderBottomValue As Integer = 0

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Padding.Top.Value) Then Integer.TryParse(styleZone.BaseStyles.Padding.Top.Value, PaddingTopValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Padding.Top.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Padding.Top.Value, PaddingTopValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Padding.Bottom.Value) Then Integer.TryParse(styleZone.BaseStyles.Padding.Bottom.Value, PaddingBottomValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Padding.Bottom.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Padding.Bottom.Value, PaddingBottomValue)

            'special cas of border : used only if the style is known. (border-left and border-right on border priority)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Border.Width.Value) AndAlso styleZone.BaseStyles.Border.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.Border.Width.Value, BorderValue) Else _
            If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Border.Width.Value) AndAlso modelStyleZone.BaseStyles.Border.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.Border.Width.Value, BorderValue)

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.BorderTop.Width.Value) AndAlso styleZone.BaseStyles.BorderTop.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.BorderTop.Width.Value, BorderTopValue) Else _
            If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.BorderTop.Width.Value) AndAlso modelStyleZone.BaseStyles.BorderTop.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.BorderTop.Width.Value, BorderTopValue)

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.BorderBottom.Width.Value) AndAlso styleZone.BaseStyles.BorderBottom.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(styleZone.BaseStyles.BorderBottom.Width.Value, borderBottomValue) Else _
            If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.BorderBottom.Width.Value) AndAlso modelStyleZone.BaseStyles.BorderBottom.Style <> StylesManager.CssItems.CssEnum.BorderStyle.novalue Then Integer.TryParse(modelStyleZone.BaseStyles.BorderBottom.Width.Value, borderBottomValue)

            If BorderTopValue <> 0 Then inner += BorderTopValue Else inner += BorderValue
            If borderBottomValue <> 0 Then inner += borderBottomValue Else inner += BorderValue

            inner += PaddingBottomValue + PaddingTopValue

            Return inner

        End Function

        ''' <summary>
        ''' research for the style zone of the margin-top and margin-bottom
        ''' </summary>
        ''' <param name="styleZone"></param>
        ''' <returns></returns>
        ''' <remarks>no use the parent's div and ONLY MARGIN</remarks>
        Private Function OuterMarginHeight(ByVal styleZone As StylesManager.StylesZone, ByVal modelStyleZone As StylesManager.StylesZone) As Integer
            If styleZone Is Nothing OrElse modelStyleZone Is Nothing Then Return 0

            Dim outer As Integer = 0

            Dim MarginTopValue As Integer = 0
            Dim MarginBottomValue As Integer = 0

            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Margin.Top.Value) Then Integer.TryParse(styleZone.BaseStyles.Margin.Top.Value, MarginTopValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Margin.Top.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Margin.Top.Value, MarginTopValue)
            If Not String.IsNullOrEmpty(styleZone.BaseStyles.Margin.Bottom.Value) Then Integer.TryParse(styleZone.BaseStyles.Margin.Bottom.Value, MarginBottomValue) Else _
                If Not String.IsNullOrEmpty(modelStyleZone.BaseStyles.Margin.Bottom.Value) Then Integer.TryParse(modelStyleZone.BaseStyles.Margin.Bottom.Value, MarginBottomValue)

            outer += MarginBottomValue + MarginTopValue
            Return outer
        End Function

#End Region

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

            Dim modelSkin As StylesManager.StylesZone = GetModelZoneImageSafe()

            'Model's value
            If Not String.IsNullOrEmpty(modelSkin.BaseStyles.Height.Value) AndAlso IsNumeric(modelSkin.BaseStyles.Height.Value) Then DivImageHeight = Integer.Parse(modelSkin.BaseStyles.Height.Value)

        End Sub

        ''' <summary>
        ''' calculation of images's height and update the _imageheight property
        ''' </summary>
        ''' <param name="imagesZone"></param>
        ''' <remarks></remarks>
        Private Sub Calculate_ImagesWidth(ByVal imagesZone As StylesManager.StylesZone, ByVal ModelStyle_ImageZone As StylesManager.StylesZone)

            'Special case where we are no image's height
            If Not String.IsNullOrEmpty(imagesZone.BaseStyles.Width.Value) AndAlso IsNumeric(imagesZone.BaseStyles.Width.Value) Then
                DivImageWidth = Integer.Parse(imagesZone.BaseStyles.Width.Value)
            Else
                Dim modelSkin As StylesManager.StylesZone = GetModelZoneImageSafe()
                Dim modelWidth As String = "" : If modelSkin IsNot Nothing Then modelWidth = modelSkin.BaseStyles.Width.Value
                If Not String.IsNullOrEmpty(modelWidth) AndAlso IsNumeric(modelWidth) Then DivImageWidth = Integer.Parse(modelWidth) : Exit Sub

                Dim BaseDivWidthValue As String = MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value
                If Not String.IsNullOrEmpty(BaseDivWidthValue) AndAlso IsNumeric(BaseDivWidthValue) Then DivImageWidth = Integer.Parse(BaseDivWidthValue)

                Dim outer_Width As Integer = Me.Outer_width(imagesZone, ModelStyle_ImageZone, True)
                If outer_Width <> 0 Then DivImageWidth = DivImageWidth - outer_Width
            End If

        End Sub

        ''' <summary>
        ''' calculate for the images list, of the new sizes.
        ''' </summary>
        ''' <param name="imagesZone"></param>
        ''' <param name="innerHeight">Internal height of image who to be used in calculations (padding and border)</param> 
        ''' <remarks> involve that if the resize has not been doing, we load the original source path and do the ratio calculation</remarks>
        Private Sub SearchDimImage(ByVal imagesZone As StylesManager.StylesZone, ByVal innerHeight As Integer)
            If ImagesList.Images.Count = 0 Then Exit Sub

            Dim newImagesInfo = New List(Of ImagesInfos)

            For Each Image In Me.ImagesList.Images
                Dim ThisImageHeight As Integer = Image.LinkSize1.ImageSize.Height
                Dim ThisImageWidth As Integer = Me.DivImageWidth

                Dim ResizeLink As LinksManager.Link

                Dim OriginImageWidth = Image.LinkOrigin.ImageSize.Width
                Dim OriginImageHeigth = Image.LinkOrigin.ImageSize.Height
                If OriginImageWidth = 0 OrElse OriginImageHeigth = 0 Then
                    'we open the image
                    Dim filePath As String = MyBase.GetLinkIOPath(Image.LinkOrigin, MyBase.Page.Culture)
                    Dim img As OBitmap = MyBase.OpenBitmap(filePath)
                    If img Is Nothing Then
                        OEMsgBox(My.Resources.text.LocalizableFormAndConverter._0173 & vbCrLf & filePath, MsgBoxType.Err, My.Resources.text.LocalizableFormAndConverter._0155) '"L'image au chemin d'accès suivant est corrompu et ne pourra donc être affichée. "  |  "Image incorrect"
                        MyBase.CloseBitmap(img)
                        Continue For 'we can't open the image  
                    End If
                    OriginImageHeigth = img.Height
                    OriginImageWidth = img.Width
                    If OriginImageWidth = 0 OrElse OriginImageHeigth = 0 Then
                        OEMsgBox(My.Resources.text.LocalizableFormAndConverter._0173 & vbCrLf & filePath, MsgBoxType.Err, My.Resources.text.LocalizableFormAndConverter._0155) 'L'image au chemin d'accès suivant est corrompu et ne pourra donc être affichée.  |  "Image incorrect"
                        MyBase.CloseBitmap(img)
                        Continue For 'we can't open the image  
                    End If
                    MyBase.CloseBitmap(img)
                End If

                'Proportional calculation

                ThisImageHeight = (ThisImageWidth * OriginImageHeigth) / (OriginImageWidth)

                'special case where height/width isn't compatible with the images
                If ThisImageHeight > DivImageHeight Then
                    'we must recalculate the size
                    ThisImageHeight = DivImageHeight
                    ThisImageWidth = (ThisImageHeight * OriginImageWidth) / (OriginImageHeigth)
                    BadProportionImg = True
                End If

                If ThisImageHeight = 0 OrElse Image.UpdateSize = True Then
                    'not automatic resizing ! we take the images's source
                    ResizeLink = Image.LinkOrigin
                Else
                    ResizeLink = Image.LinkSize1
                End If
                newImagesInfo.Add(New ImagesInfos(ResizeLink, Image.LinkOrigin, Image.PageLink, ThisImageHeight, ThisImageHeight + innerHeight, ThisImageWidth, 0, Image.Title))
            Next

            Me._imagesInfo = newImagesInfo

        End Sub

#End Region

    End Class
End Namespace

