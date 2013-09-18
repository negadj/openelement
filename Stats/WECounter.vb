#Region "Header"

'NameSpace of element (create yours ex: Elements.MyCompagny)

#End Region 'Header

Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Elements
Imports openElement.WebElement.ElementWECommon.Stats.Forms
Imports openElement.WebElement.StylesManager

Imports WebElement.Elements.Stats.Editors
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Stats

    ''' <summary>
    ''' This class is the source code of openElement's element : WECounter 
    ''' Create a public class with inherit ElementBase (complete namespace : openElement.WebElement.Elements.ElementBase) 
    ''' or another ElementBase class daughter (ElementBaseTextIcon or WEDynamic
    ''' See comments in elementBase for all explanations of methods of mybase used in this class.
    '''  the class's name must to be unique in the namespace. he can't will be changing after
    ''' This class must to be  "Serializable"
    ''' </summary>
    ''' <remarks>it'd be better of us to subject the class name</remarks>
    <Serializable> _
    Public Class WECounter
        Inherits ElementBase

        #Region "Fields"

        'For public property metaTags, see specific xml docs                                                                                                InzM3t5itgmm
        ''' <summary>
        ''' config data of WECounter Element.  
        ''' </summary>
        ''' <remarks></remarks>
        Private _Config As FrmCounterConfig.WECounterConfig

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
            MyBase.New(EnuElementType.PageEdit, "WECounter", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None

            'careful: that is the default value at element creating and not the obligatory default value
            Config.CountMethod = FrmCounterConfig.EnuMethodCounter.All
            Config.InitialValue = 0
            Config.TypeCounter = FrmCounterConfig.EnuTypeCounter.All
            Config.Lenght = 4
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        ''' <summary>
        ''' Public property of _Config
        ''' </summary>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N001"), _
        LocalizableDescAtt("_D001"), _
        Editor(GetType(UITypeCounter), GetType(UITypeEditor)), _
        ExportVar(ExportVar.EnuVarType.All), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Config() As FrmCounterConfig.WECounterConfig
            Get
                If _Config Is Nothing Then _Config = New FrmCounterConfig.WECounterConfig
                Return _Config
            End Get
            Set(ByVal value As FrmCounterConfig.WECounterConfig)
                _Config = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        ''' <summary>         
        ''' Required function who allow to complete elementInfo object        
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            'Element's name displayed in element's list
            info.ToolBoxCaption = LocalizableOpen._0026 'this text is a localizable variable for traduction
            'Element's description
            info.ToolBoxDescription = LocalizableOpen._0027
            'Number of major version
            info.VersionMajor = 1
            'Number of minor version
            info.VersionMinor = 0
            'openElement's toolsbox group which the item belongs
            info.GroupName = "NBGroupStats"
            'Icon display in the openElement's toolsbox (size : 16*16px)
            info.ToolBoxIco = My.Resources.WECounter
            'Automatic opening property when the element will be adding in the page
            info.AutoOpenProperty = "Config"

            'Add a fast acces of the property in bottom bar (Icon display below the element when he's selecting)
            '(parameter: Property's name, associated icon's name, associated tooltip text)
            info.SortPropertyList.Add(New SortProperty("Config", "tools.png", LocalizableOpen._0030))
            Return info
        End Function

        ''' <summary>
        '''  Required function who allow to add external script (spécific or shared script)    
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnInitExternalFiles()
            'function of adding from external script : add scripts to the project and add the link into html page
            'Careful, all path should be relatif according to the parent folder of files

            'Here, addition of one file of javascript type (param: type of file, path in openElement project, final path of copied file in the web project)
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WECounter.js", "WEFiles/Client/WECounter.js")

            'Here, addition of on file of php script type
            MyBase.AddExternalScripts(EnuScriptType.Php, "ElementsLibrary\Common\Server\WECounter.php", "WEFiles/Server/WECounter.php")
            MyBase.OnInitExternalFiles()
        End Sub

        ''' <summary>
        ''' start event. Necessary for configuration of element
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnOpen()
            'configuration of style zones. Here, we are only one specific zone
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("Digit", LocalizableOpen._0028, LocalizableOpen._0029))

            'Obligatory at end
            MyBase.OnOpen(configStylesZones)
        End Sub

        'html render functions. (obligatory for element of type 'EnuElementType.PageEdit')
        ''' <summary>
        ''' Main event of element's render. it's obligatory for element at type of EnuElementType.PageEdit
        ''' here, we write the html of the element
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            Dim initialValueLenght As Integer = Config.InitialValue.ToString.Length

            'obligatory at beginning
            MyBase.RenderBeginTag(writer)

            'You have three phase for render
            '* Editor : writting of html render  for editor zone into openelement
            '* Export : writting of final html render: it's the html code for .htm file upload on server
            '* Preview : writting of html render for preview file

            'Here, we write the counter's html code for final file to upload (the php code is active only on the server)
            If MyBase.Page.RenderMode <> openElement.WebElement.Page.EnuTypeRenderMode.Export Then
                For i = 1 To Me.Config.Lenght - initialValueLenght
                    Call DivRender(writer, "0")
                Next
                For i = 1 To Me.Config.Lenght
                    If initialValueLenght >= i Then Call DivRender(writer, Config.InitialValue.ToString.Chars(i - 1))
                Next
            End If
            'obligatory at end
            MyBase.RenderEndTag(writer)
        End Sub

        Private Sub DivRender(ByVal writer As HtmlWriter, ByVal value As String)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", GetStyleZoneClass("Digit"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.Write(value)
            writer.WriteEndTag("div")
            writer.WriteLine()
        End Sub

        #End Region 'Methods

    End Class

End Namespace

