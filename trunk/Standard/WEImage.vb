#Region "Header"

'NameSpace of element (create yours ex: Elements.MyCompagny)

#End Region 'Header

Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Drawing.Imaging
Imports System.Text
Imports System.Web.UI

Imports openElement
Imports openElement.Tools
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements
Imports openElement.WebElement.LinksManager

Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Imports Path = System.IO.Path

Namespace Elements.Standard

    ''' <summary>
    ''' This class is the source code of openElement's element : WEImage (Image)
    ''' Create a public class with inherit ElementBase (complete namespace : openElement.WebElement.Elements.ElementBase)
    ''' See comments in elementBase for all explanations of methods of mybase used in this class.
    '''  the class's name must to be unique in the namespace. he can't will be changing after
    ''' This class must to be  "Serializable"
    ''' </summary>
    ''' <remarks>it'd be better of us to subject the class name</remarks>
    <Serializable> _
    Public Class WEImage
        Inherits ElementBase

        #Region "Fields"

        ''' <summary>
        ''' Alternat text of image : text is displaying if the image path is in fail, according to culture of page
        ''' </summary>
        Private _AlternateText As LocalizableString

        ''' <summary> 
        ''' true if we uses the source image. False if it's the resize image
        ''' </summary>
        ''' <remarks>This value is automatically updated by manuel resizing of user. That can too to be updated in the property grid</remarks>
        Private _DefaultImage As Boolean

        'For public property metaTags, see specific xml docs
        ''' <summary>
        ''' Object with all paths of image according to culture (language) of page
        ''' </summary>
        Private _ImageLink As Link

        ''' <summary>
        ''' object with all paths of resizing image (only if necessary) according to culture of page
        ''' </summary>
        Private _ImageResizeLink As Link

        ''' <summary>
        ''' Image size in html page
        ''' </summary>
        Private _ImageSize As Size

        ''' <summary>
        ''' This property is tagging as NonSerialized(), it will not be saving in the .dat file
        ''' </summary>
        ''' <remarks></remarks>
        <NonSerialized> _
        Private _LockResizeEvent As Boolean

        ''' <summary>
        ''' Object with all links on mouse click event, according to culture of page
        ''' </summary>
        Private _PageLink As Link

        #End Region 'Fields

        #Region "Constructors"

        ''' <summary>
        ''' Obligatory configuration of constructor. The base constructor call is necessary 
        ''' for parameter, see comments in ElementBase class
        ''' </summary>
        ''' <param name="page"> Page reference which element belongs </param>
        ''' <param name="parentID"> Unique ID of parent container</param>
        ''' <param name="templateName"> template's name which element belongs</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEImage", page, parentID, templateName)
            MyBase.NumUpdate = 1
            Me.DefaultImage = True
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        ''' <summary>
        ''' Alternat text of image : text is displaying if the image path is in fail, according to culture of page
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N004"), _
        LocalizableDescAtt("_D004"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property AlternateText() As LocalizableString
            Get
                If _AlternateText Is Nothing Then
                    _AlternateText = New LocalizableString("")
                End If
                Return _AlternateText
            End Get
            Set(ByVal value As LocalizableString)
                _AlternateText = WebElem.PropertiesLocalizableStringFormat(value, MyBase.Page.Culture, Enu.ProgLanguage.Html)
            End Set
        End Property

        ''' <summary>
        ''' Image relativ path (localizable)
        ''' </summary>
        ''' <remarks>should not be at nothing (by default, it the default image's path)</remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N002"), _
        LocalizableDescAtt("_D002"), _
        Editor(GetType(UITypeLinkFile), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.ElementWithCss), _
        ConfigBiblio(True, False, False, False, False)> _
        Public Property ImageLink() As Link
            Get
                If _ImageLink Is Nothing Then
                    _ImageLink = New Link()
                End If
                If DefaultImage Then _ImageLink.BannedFromUpload = False Else _ImageLink.BannedFromUpload = True
                Return _ImageLink
            End Get
            Set(ByVal value As Link)
                _ImageLink = value
                SetDefaultSize()
            End Set
        End Property

        ''' <summary>
        ''' paths of resizing image (only if necessary) according to culture of page
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        Public Property ImageResizeLink() As Link
            Get
                If _ImageResizeLink Is Nothing Then
                    _ImageResizeLink = New Link()
                End If
                If DefaultImage Then _ImageResizeLink.BannedFromUpload = True Else _ImageResizeLink.BannedFromUpload = False
                Return _ImageResizeLink
            End Get
            Set(ByVal value As Link)
                _ImageResizeLink = value
            End Set
        End Property

        ''' <summary>
        ''' links on mouse click event, according to culture of page
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N003"), _
        LocalizableDescAtt("_D003"), _
        Editor(GetType(UITypeLinkPage), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLinkFile)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property PageLink() As Link
            Get
                If _PageLink Is Nothing Then _PageLink = New Link()
                Return _PageLink
            End Get
            Set(ByVal value As Link)
                _PageLink = value
            End Set
        End Property

        ''' <summary>
        ''' true if we uses the default image
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N093"), _
        LocalizableDescAtt("_D094"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Protected Friend Property DefaultImage() As Boolean
            Get
                Return _DefaultImage

            End Get
            Set(ByVal value As Boolean)
                _DefaultImage = value
                If _DefaultImage Then
                    _ImageResizeLink = Nothing
                End If
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        ' See comments in ElementBase class
        Public Overrides Function GetLocalizableStringsForTranslationSystem( _
            ByVal accListLS As Dictionary(Of String, LocalizableString), _
            ByVal accListInfo As Dictionary(Of String, String), _
            Optional ByVal onlyNonEmpty As Boolean = True) As Boolean
            If accListLS Is Nothing Or accListInfo Is Nothing Then Return False

            If _AlternateText Is Nothing OrElse (onlyNonEmpty AndAlso _AlternateText.IsEmpty) Then Return False

            Dim lsID As String = "WEImage." & ID & ".AltText"
            accListLS(lsID) = _AlternateText

            If Not String.IsNullOrEmpty(Me.Name) Then
                accListInfo(lsID) = "Element name: " & Me.Name & " (Image)"
            End If

            Return True
        End Function

        ''' <summary>
        ''' get the image path (source or resize path as the case)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetStrImageLink() As String
            If Me.DefaultImage Then
                Return MyBase.GetLink(Me.ImageLink)
            Else
                Return MyBase.GetLink(Me.ImageResizeLink)
            End If
        End Function

        ''' <summary>         
        ''' Required function who allow to complete elementInfo object        
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            'Element's name displayed in element's list
            info.ToolBoxCaption = LocalizableOpen._0007 'this text is a localizable variable for traduction
            'Element's description
            info.ToolBoxDescription = LocalizableOpen._0008 '
            'Number of major version
            info.VersionMajor = 1
            'Number of minor version
            info.VersionMinor = 0
            'openElement's toolsbox group which the item belongs
            info.GroupName = "NBGroupStandard"
            'Icon display in the openElement's toolsbox (size : 16*16px)
            info.ToolBoxIco = My.Resources.WEImage
            'Automatic opening property when the element will be adding in the page
            info.AutoOpenProperty = "ImageLink"

            'Add a fast acces of the property in bottom bar (Icon display below the element when he's selecting)
            '(parameter: Property's name, associated icon's name, associated tooltip text)
            info.SortPropertyList.Add(New SortProperty("ImageLink", "folder.png", LocalizableOpen._0009))
            info.SortPropertyList.Add(New SortProperty("PageLink", "link.png", LocalizableOpen._0010))
            Return info
        End Function

        ''' <summary>
        ''' start event. Necessary for configuration of element
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnOpen()
            'Obligatory at end
            MyBase.OnOpen()
        End Sub

        ''' <summary>
        ''' Event called before the page render. Don't forget to call the parent class's event
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnPageBeforeRender(ByVal mode As openElement.WebElement.Page.EnuTypeRenderMode)
            MyBase.OnPageBeforeRender(mode)
        End Sub

        ''' <summary>
        ''' Event called at the page loading in the editor
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnPageInit()
            If MyBase.NumUpdate = 0 Then
                CreateImageResizeLink()
                MyBase.NumUpdate = 1
            End If
            MyBase.OnPageInit()
        End Sub

        ''' <summary>
        ''' Event called after one manual image resize.  Don't forget to call the parent class's event
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnResizeEnd()
            If _LockResizeEvent Then Exit Sub
            CreateImageResizeLink()
            MyBase.LiveUpdateHtmlProperty("img", "src", GetStrImageLink)
            MyBase.OnResizeEnd()
        End Sub

        ''' <summary>
        ''' Event called before the changing of resizing's type of element 
        ''' </summary>
        ''' <param name="oldType"></param>
        ''' <param name="newType"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnTypeResizeChange(ByVal oldType As EnuTypeResize, ByRef newType As EnuTypeResize)
            _LockResizeEvent = True
            If String.IsNullOrEmpty(MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value) Then
                MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value = _ImageSize.Width
            End If
            If String.IsNullOrEmpty(MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Value) Then
                MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Value = _ImageSize.Height
            End If
            _LockResizeEvent = False
            MyBase.OnTypeResizeChange(oldType, newType)
        End Sub

        ''' <summary>
        ''' Main event of element's render. it's obligatory for element at type of EnuElementType.PageEdit
        ''' here, we write the html of the element
        ''' </summary>
        ''' <param name="writer">Writer object</param>
        ''' <remarks></remarks>
        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            Dim strPageLink As String = MyBase.GetLink(Me.PageLink)
            Dim strImageLink As String = GetStrImageLink()

            'to add obligatory at begining of element's html render
            MyBase.RenderBeginTag(writer)

            'Specific html code of element WEImage
            If Not String.IsNullOrEmpty(strPageLink) Then
                writer.WriteBeginTag("a")
                writer.WriteHrefAttribute(Me, Me.PageLink, True)
                writer.Write(HtmlTextWriter.TagRightChar)
            End If

            If Not String.IsNullOrEmpty(strImageLink) Then
                writer.WriteBeginTag("img")
                writer.WriteAttribute("style", GetImageStyle())
                writer.WriteAttribute("src", strImageLink)
                writer.WriteAttribute("alt", Me.AlternateText.GetValue(MyBase.Page.Culture))
                writer.Write(HtmlTextWriter.SelfClosingTagEnd)
            End If

            If Not String.IsNullOrEmpty(strPageLink) Then
                writer.WriteEndTag("a")
            End If

            'to Add obligarory at ending of element's html render
            MyBase.RenderEndTag(writer)
        End Sub

        ''' <summary>
        ''' Private method for to see if the image must to be resizing
        ''' It's determinate by the source image sizing and the image size on page. 
        ''' that's allow to reduce the image's weight et so, the page loading time.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CreateImageResizeLink()
            If _ImageLink Is Nothing Then Exit Sub

            Try

                _LockResizeEvent = True

                Dim originFullPath As String = MyBase.GetLinkIOPath(Me.ImageLink)
                If String.IsNullOrEmpty(originFullPath) Then Exit Sub

                Dim imageFormat As ImageFormat = Picture.ImageFormatByExt(Path.GetExtension(originFullPath))
                If imageFormat.Equals(ImageFormat.Gif) Then
                    Me.DefaultImage = True
                    Exit Sub
                End If

                Dim originBitmap As OBitmap = MyBase.OpenBitmap(originFullPath)
                If originBitmap Is Nothing OrElse originBitmap.Bitmap Is Nothing Then ' originBitmap Is Nothing may happen (= happened for one of user projects) on project upgrade (becomes important as we now may call this function on PageInit
                    Exit Sub
                End If

                Dim originWidth As Integer = originBitmap.Bitmap.Width
                Dim originHeight As Integer = originBitmap.Bitmap.Height
                Dim newWidth As String = MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value
                Dim newHeight As String = MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Value

                If MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Auto Or String.IsNullOrEmpty(newWidth) Then
                    newWidth = originWidth
                    MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value = originWidth
                End If

                If MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Auto Or String.IsNullOrEmpty(newHeight) Then
                    newHeight = originHeight
                    MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Value = originHeight
                End If

                If originWidth = newWidth And originHeight = newHeight Then
                    Me.DefaultImage = True
                    If MyBase.NumUpdate = 0 Then
                        MyBase.TypeResize = EnuTypeResize.None
                    End If
                Else

                    For Each culture As String In ImageLink.GetListSitePath().Keys

                        Dim fullCulturePath As String = MyBase.GetLinkIOPath(Me.ImageLink, culture)

                        Dim cultureBitmap As OBitmap = MyBase.OpenBitmap(fullCulturePath)
                        cultureBitmap.Resize(New Size(newWidth, newHeight))

                        Dim linkPath As String = String.Concat("WEFiles/Image/WEImage/", Me.ImageResizeLink.ID, culture, Path.GetExtension(fullCulturePath))
                        MyBase.CreateAutoRessourceByBitmap(Me.ImageResizeLink, Link.EnuLinkType.ElementImage, cultureBitmap.Bitmap, linkPath, culture)

                        MyBase.CloseBitmap(cultureBitmap)

                    Next

                    Me.DefaultImage = False

                    If MyBase.NumUpdate = 0 Then

                        If Not originWidth = newWidth And Not originHeight = newHeight Then
                            MyBase.TypeResize = EnuTypeResize.Both
                        ElseIf Not originWidth = newWidth Then
                            MyBase.TypeResize = EnuTypeResize.Width
                        ElseIf Not originHeight = newHeight Then
                            MyBase.TypeResize = EnuTypeResize.Height
                        End If

                    End If

                End If

                Me.SelectLinkToUpload()

                MyBase.CloseBitmap(originBitmap)

            Catch ex As Exception
                OEBug.Capture(ex, True, True)
            Finally
                UpdateMinMaxSize()
                _LockResizeEvent = False
            End Try
        End Sub

        'html render functions. (obligatory for element of type 'EnuElementType.PageEdit')
        ''' <summary>
        ''' writing css property inside image tag
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetImageStyle() As String
            Dim builder As New StringBuilder()

            If MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Auto Then
                builder.Append(String.Concat("height:", _ImageSize.Height, "px;"))
            Else
                If _ImageSize.Height > 0 And _ImageSize.Height < 15 Then
                    Dim prop As Integer = Math.Round((100 * _ImageSize.Height) / 15, 0)
                    builder.Append(String.Concat("height:", prop, "%;"))
                End If
            End If

            If MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Auto Then
                builder.Append(String.Concat("width:", _ImageSize.Width, "px;"))
            Else
                If _ImageSize.Width > 0 And _ImageSize.Width < 15 Then
                    Dim prop As Integer = Math.Round((100 * _ImageSize.Width) / 15, 0)
                    builder.Append(String.Concat("width:", prop, "%;"))
                End If
            End If

            Return builder.ToString
        End Function

        ''' <summary>
        ''' selects which resource to upload (source or resize image)
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SelectLinkToUpload()
            If Me.DefaultImage Then
                Me.ImageLink.BannedFromUpload = False
                Me.ImageResizeLink.BannedFromUpload = True
            Else
                Me.ImageLink.BannedFromUpload = True
                Me.ImageResizeLink.BannedFromUpload = False
            End If
        End Sub

        ''' <summary>
        ''' Private Method for to check the image size. this graphic element must to be a mininal size (15*15px). It's necessary for select him at the mouve clic event in the editor
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetDefaultSize()
            Dim imgSrc = MyBase.GetLinkIOPath(Me.ImageLink)
            If String.IsNullOrEmpty(imgSrc) Then _ImageSize = New Size(15, 15) : Exit Sub

            'Get bitmap size
            Dim originBitmap As OBitmap = MyBase.OpenBitmap(imgSrc)
            If originBitmap.Bitmap Is Nothing Then Exit Sub
            _ImageSize = originBitmap.Bitmap.Size
            MyBase.CloseBitmap(originBitmap)

            'minimal width is 15px
            If _ImageSize.Width < 15 Then
                MyBase.StylesSkin.BaseDiv.BaseStyles.Width.SetCss(15)
            Else
                MyBase.StylesSkin.BaseDiv.BaseStyles.Width.SetCss(_ImageSize.Width)
            End If

            'minimal height is 15px
            If _ImageSize.Height < 15 Then
                MyBase.StylesSkin.BaseDiv.BaseStyles.Height.SetCss(15)
            Else
                MyBase.StylesSkin.BaseDiv.BaseStyles.Height.SetCss(_ImageSize.Height)
            End If
        End Sub

        ''' <summary>
        ''' Private method for to update the css size style of parent div of element.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub UpdateMinMaxSize()
            If MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Auto Then
                MyBase.StylesSkin.BaseDiv.BaseStyles.MinHeight.SetCss(_ImageSize.Height)
                MyBase.StylesSkin.BaseDiv.BaseStyles.MaxHeight.SetCss(_ImageSize.Height)
            Else
                MyBase.StylesSkin.BaseDiv.BaseStyles.MinHeight.SetCss("")
                MyBase.StylesSkin.BaseDiv.BaseStyles.MaxHeight.SetCss("")
            End If

            If MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Auto Then
                MyBase.StylesSkin.BaseDiv.BaseStyles.MinWidth.SetCss(_ImageSize.Width)
                MyBase.StylesSkin.BaseDiv.BaseStyles.MaxWidth.SetCss(_ImageSize.Width)
            Else
                MyBase.StylesSkin.BaseDiv.BaseStyles.MinWidth.SetCss("")
                MyBase.StylesSkin.BaseDiv.BaseStyles.MaxWidth.SetCss("")
            End If
        End Sub

        #End Region 'Methods

    End Class

End Namespace

