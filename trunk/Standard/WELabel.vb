#Region "Header"

'NameSpace of element (create yours ex: Elements.MyCompagny)

#End Region 'Header

Imports System.ComponentModel
Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Elements
Imports openElement.WebElement.StylesManager

Imports WebElement.Elements.Standard.Editors.Converter
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Standard

    ''' <summary>
    ''' This class is the source code of openElement's element : WELabel (text)
    ''' Create a public class with inherit ElementBase (complete namespace : openElement.WebElement.Elements.ElementBase) 
    ''' or another ElementBase class daughter (ElementBaseTextIcon or WEDynamic
    ''' See comments in elementBase for all explanations of methods of mybase used in this class.
    '''  the class's name must to be unique in the namespace. he can't will be changing after
    ''' This class must to be  "Serializable"
    ''' </summary>
    ''' <remarks>it'd be better of us to subject the class name</remarks>
    <Serializable> _
    Public Class WELabel
        Inherits ElementBaseTextIcon

        #Region "Fields"

        ''' <summary>
        ''' tag 'H' write around the label in html page. If value is none then no tag is writing
        ''' </summary>
        ''' <remarks></remarks>
        Private _BaliseHx As EnuBaliseH

        ''' <summary>
        ''' list of Texts values of element according to page culture
        ''' </summary>
        ''' <remarks></remarks>
        <ContainsLinks> _
        Private _Text As LocalizableHtml

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
            MyBase.New(EnuElementType.PageEdit, "WELabel", page, parentID, templateName)

            'resizing mode by default
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        #End Region 'Constructors

        #Region "Enumerations"

        ''' <summary>
        ''' List ofHTML headings (important for seo)
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum EnuBaliseH As Integer
            None = 0
            H1 = 1
            H2 = 2
            H3 = 3
            H4 = 4
            H5 = 5
            H6 = 6
        End Enum

        #End Region 'Enumerations

        #Region "Properties"

        ''' <summary>
        ''' Public property of private variable '_BaliseHx' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Expert), _
        Ressource.localizable.LocalizableNameAtt("_N154"), _
        LocalizableDescAtt("_D154"), _
        TypeConverter(GetType(TConvEnuBaliseH)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property BaliseHx() As EnuBaliseH
            Get
                Return _BaliseHx
            End Get
            Set(ByVal value As EnuBaliseH)
                _BaliseHx = value
            End Set
        End Property

        ''' <summary>
        ''' Public property of private variable '_text' 
        ''' value should not be at nothing  
        ''' Browsable(False) means that the property isn't showing in the element property grid
        ''' see in openElement's documentation, the differents 'dataType' available  
        ''' </summary>
        <Browsable(False)> _
        Public Property Text() As LocalizableHtml
            Get
                If _Text Is Nothing Then _Text = New LocalizableHtml(LocalizablePropertyDefaultValue._0002) 'Mon texte simple")
                Return _Text
            End Get
            Set(ByVal value As LocalizableHtml)
                _Text = value
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

            If _Text Is Nothing OrElse (onlyNonEmpty AndAlso _Text.IsEmpty) Then Return False

            Dim lsID As String = "WELabel." & ID & ".Text"
            accListLS(lsID) = _Text

            If Not String.IsNullOrEmpty(Me.Name) Then
                accListInfo(lsID) = "Element name: " & Me.Name & " (Single-line text)"
            End If

            Return True
        End Function

        ''' <summary>         
        ''' Required function who allow to complete elementInfo object        
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            'Element's name displayed in element's list
            info.ToolBoxCaption = LocalizableOpen._0005 'this text is a localizable variable for traduction
            'Element's description
            info.ToolBoxDescription = LocalizableOpen._0006 '"Ajouter un texte simple ligne."
            'Number of major version
            info.VersionMajor = 2
            'Number of minor version
            info.VersionMinor = 0
            'openElement's toolsbox group which the item belongs
            info.GroupName = "NBGroupStandard"
            'Icon display in the openElement's toolsbox (size : 16*16px)
            info.ToolBoxIco = My.Resources.WELabel

            'contrary to WEImage element, WELabel hasn't neither Automatic opening property nor sortPropertyList value

            Return info
        End Function

        ''' <summary>
        ''' start event. Necessary for configuration of element
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnOpen()
            'configuration of style zones. Here, we are only one specific zone
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("Text", LocalizableOpen._0300, LocalizableOpen._0300))

            MyBase.TextIconZoneName = "Text"

            'Obligatory at end
            MyBase.OnOpen(configStylesZones)
        End Sub

        ''' <summary>
        ''' Main event of element's render. it's obligatory for element at type of EnuElementType.PageEdit
        ''' here, we write the html of the element
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            'to add obligatory at begining of element's html render
            MyBase.RenderBeginTag(writer)

            If Not BaliseHx = EnuBaliseH.none Then
                Select Case BaliseHx
                    Case EnuBaliseH.H1
                        writer.WriteBeginTag("h1")
                    Case EnuBaliseH.H2
                        writer.WriteBeginTag("h2")
                    Case EnuBaliseH.H3
                        writer.WriteBeginTag("h3")
                    Case EnuBaliseH.H4
                        writer.WriteBeginTag("h4")
                    Case EnuBaliseH.H5
                        writer.WriteBeginTag("h5")
                    Case EnuBaliseH.H6
                        writer.WriteBeginTag("h6")
                End Select
                writer.WriteAttribute("class", "ContentBox")
                writer.Write(HtmlTextWriter.TagRightChar)
            End If

            Dim textAttr As New Dictionary(Of String, String)
            textAttr.Add("class", MyBase.GetStyleZoneClass("Text"))
            writer.WriteHtmlBlockEdit(Me, "Text", False, textAttr)

            Select Case BaliseHx
                Case EnuBaliseH.H1
                    writer.WriteEndTag("h1")
                Case EnuBaliseH.H2
                    writer.WriteEndTag("h2")
                Case EnuBaliseH.H3
                    writer.WriteEndTag("h3")
                Case EnuBaliseH.H4
                    writer.WriteEndTag("h4")
                Case EnuBaliseH.H5
                    writer.WriteEndTag("h5")
                Case EnuBaliseH.H6
                    writer.WriteEndTag("h6")
            End Select

            'Obligatory at end
            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

