Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements
Imports openElement.WebElement.LinksManager
Imports openElement.WebElement.StylesManager
Imports openElement.WebElement.StylesManager.CssItems

Imports WebElement.Elements.Form.Editors.Converter
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Imports Page = openElement.WebElement.Page

Namespace Elements.Form

    <Serializable> _
    Public Class WECaptchaV2
        Inherits ElementBase

        #Region "Fields"

        Private _CharAngleMax As Integer
        Private _CharClear As Integer
        Private _CharColor As Color
        Private _CharColorHex As String
        Private _CharColorRnd As Boolean
        Private _CharColorRndLevel As EnuCharColorRndLevel
        Private _Charel As String
        Private _CharNbMax As Integer
        Private _CharNbMin As Integer
        Private _CharSizeMax As CssFontSize
        Private _CharSizeMin As CssFontSize
        Private _CharSpace As CssUnit
        Private _CharUp As Boolean
        Private _CryptUseMax As Integer
        Private _CryptUseTimerInt As Integer 'correct
        Private _DifUpLow As Boolean
        Private _NbCircleMax As Integer
        Private _NbCircleMin As Integer
        Private _NoiseColorChar As EnuNoiseColorChar
        Private _NoiseLineMax As Integer
        Private _NoiseLineMin As Integer
        Private _NoisePxMax As Integer
        Private _NoisePxMin As Integer
        Private _NoiseUp As Boolean
        Private _TextError As LocalizableHtml
        Private _Tfont As Link

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WECaptcha2", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Width

            CharColor = Color.Black
            CharColorRnd = True
            CharColorRndLevel = EnuCharColorRndLevel.Light

            CharClear = False ' DD this property is Boolean (even if _CharClear is Integer), and php code is adapted accordingly

            Tfont = New Link()

            'we config the default value
            Charel = "ABCDEFGHKLMNPRTWXYZ234569"
            DifUpLow = False
            CharNbMin = 4
            CharNbMax = 6
            CharSpace.Value = 20
            CharSizeMin.Size.Value = 14
            CharSizeMax.Size.Value = 15
            CharAngleMax = 25
            CharColorRndLevel = EnuCharColorRndLevel.Dark
            CharUp = True
            NoisePxMin = 10
            NoisePxMax = 20
            NoiseLineMin = 5
            NoiseLineMax = 10
            NbCircleMin = 2
            NbCircleMax = 4
            NoiseColorChar = EnuNoiseColorChar.Same
            NoiseUp = False
            CryptUseTimer = 0
            CryptUseMax = 1000
        End Sub

        #End Region 'Constructors

        #Region "Enumerations"

        ''' <summary>
        ''' Character's lightness level, if aleatory choise (0->4)   
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum EnuCharColorRndLevel As Short
            ''' <summary>
            ''' none select
            ''' </summary>
            ''' <remarks></remarks>
            None = 0
            ''' <summary>
            ''' very dark color (mainly for the light backcolor)
            ''' </summary>
            ''' <remarks></remarks>
            VeryDark = 1
            ''' <summary>
            ''' dark color
            ''' </summary>
            ''' <remarks></remarks>
            Dark = 2
            ''' <summary>
            ''' light color
            ''' </summary>
            ''' <remarks></remarks>
            Light = 3
            ''' <summary>
            ''' very light color (mainly for the light backcolor)
            ''' </summary>
            ''' <remarks></remarks>
            VeryLight = 4
        End Enum

        ''' <summary>
        ''' Noise : writing's pixel, line and circle's color 
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum EnuNoiseColorChar As Short
            ''' <summary>
            ''' writing's color
            ''' </summary>
            ''' <remarks></remarks>
            Same = 1
            ''' <summary>
            ''' aleatory color
            ''' </summary>
            ''' <remarks></remarks>
            Ramdom = 3
        End Enum

        #End Region 'Enumerations

        #Region "Properties"

        ''' <summary>
        ''' Angle   (0-360)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
        Ressource.localizable.LocalizableNameAtt("_N170"), _
        LocalizableDescAtt("_D170"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CharAngleMax() As Integer
            Get
                Return _CharAngleMax
            End Get
            Set(ByVal value As Integer)
                If value < 0 Then value = 0
                If value > 360 Then value = 360
                _CharAngleMax = value
            End Set
        End Property

        ''' <summary>
        ''' transparents characters(0->127)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
        Ressource.localizable.LocalizableNameAtt("_N162"), _
        LocalizableDescAtt("_D162"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CharClear() As Boolean
            Get ' DD _CharClear is Integer, so I add transfomration (also modified PHP code)
                If _CharClear <= 0 Then Return False ' opaque
                Return True ' transparent
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    _CharClear = 127 ' transparent
                Else
                    _CharClear = 0 ' opaque
                End If
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
        Ressource.localizable.LocalizableNameAtt("_N159"), _
        LocalizableDescAtt("_D159"), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CharColor() As Color
            Get
                Return _CharColor
            End Get
            Set(ByVal value As Color)

                _CharColorHex = value.ToArgb().ToString("X").Remove(0, 2)
                _CharColor = value
            End Set
        End Property

        <Browsable(False), _
        ExportVar(ExportVar.EnuVarType.Php)> _
        Public Property CharColorHex() As String
            Get
                Return _CharColorHex
            End Get
            Set(ByVal value As String)
                _CharColorHex = value
            End Set
        End Property

        ''' <summary>
        ''' randon characters color
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
        Ressource.localizable.LocalizableNameAtt("_N160"), _
        LocalizableDescAtt("_D160"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CharColorRnd() As Boolean
            Get
                Return _CharColorRnd
            End Get
            Set(ByVal value As Boolean)
                _CharColorRnd = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
        Ressource.localizable.LocalizableNameAtt("_N161"), _
        LocalizableDescAtt("_D161"), _
        TypeConverter(GetType(TConvEnuCharColorRndLevelV2)), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CharColorRndLevel() As EnuCharColorRndLevel
            Get
                Return _CharColorRndLevel
            End Get
            Set(ByVal value As EnuCharColorRndLevel)
                _CharColorRndLevel = value
            End Set
        End Property

        ''' <summary>
        ''' authorised characters 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>no use in php because $crypteasy = true; in cfg.php</remarks>
        <Browsable(False)> _
        Public Property Charel() As String
            Get
                Return _Charel
            End Get
            Set(ByVal value As String)
                _Charel = value
            End Set
        End Property

        ''' <summary>
        ''' cryptogram max char
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N166"), _
        LocalizableDescAtt("_D166"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CharNbMax() As Integer
            Get
                Return _CharNbMax
            End Get
            Set(ByVal value As Integer)
                If value < 4 Then value = 4
                _CharNbMax = value
            End Set
        End Property

        ''' <summary>
        ''' Crypogram min char
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N165"), _
        LocalizableDescAtt("_D165"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CharNbMin() As Integer
            Get
                Return _CharNbMin
            End Get
            Set(ByVal value As Integer)
                If value < 4 Then value = 4
                _CharNbMin = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
        Ressource.localizable.LocalizableNameAtt("_N169"), _
        LocalizableDescAtt("_D169"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CharSizeMax() As CssFontSize
            Get
                If _CharSizeMax Is Nothing Then _CharSizeMax = New CssFontSize
                Return _CharSizeMax
            End Get
            Set(ByVal value As CssFontSize)
                If value.Size.Value < CharSizeMin.Size.Value Then CharSizeMin = value
                _CharSizeMax = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
        Ressource.localizable.LocalizableNameAtt("_N168"), _
        LocalizableDescAtt("_D168"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CharSizeMin() As CssFontSize
            Get
                If _CharSizeMin Is Nothing Then _CharSizeMin = New CssFontSize
                Return _CharSizeMin
            End Get
            Set(ByVal value As CssFontSize)
                If value.Size.Value > CharSizeMax.Size.Value Then CharSizeMax = value
                _CharSizeMin = value
            End Set
        End Property

        ''' <summary>
        ''' space between char (in pixel)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
        Ressource.localizable.LocalizableNameAtt("_N167"), _
        LocalizableDescAtt("_D167"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CharSpace() As CssUnit
            Get
                If _CharSpace Is Nothing Then _CharSpace = New CssUnit
                Return _CharSpace
            End Get
            Set(ByVal value As CssUnit)
                _CharSpace = value
            End Set
        End Property

        ''' <summary>
        ''' aleatory vertical moving of characters(true/false)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
        Ressource.localizable.LocalizableNameAtt("_N171"), _
        LocalizableDescAtt("_D171"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CharUp() As Boolean
            Get
                Return _CharUp
            End Get
            Set(ByVal value As Boolean)
                _CharUp = value
            End Set
        End Property

        ''' <summary>
        ''' cryptogram pixel height
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N156"), _
        LocalizableDescAtt("_D156"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CryptHeight() As CssUnit
            Get
                Dim height = MyBase.StylesSkin.FindStylesZone("Cryptogram").BaseStyles.Height(True)
                If height Is Nothing OrElse height.GetNumber = 0 Then
                    height = New CssUnit()
                    height.Value = 30
                    height.Unit = CssEnum.Unit.pixel
                End If
                Return height
            End Get
            Set(ByVal value As CssUnit)
                MyBase.StylesSkin.FindStylesZone("Cryptogram").FindStyles(StylesZone.EnuStyleState.Normal).Height = value
            End Set
        End Property

        ''' <summary>
        ''' max nb of the user can reload then cryptogram 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N158"), _
        LocalizableDescAtt("_D158"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CryptUseMax() As Integer
            Get
                Return _CryptUseMax
            End Get
            Set(ByVal value As Integer)
                _CryptUseMax = value
            End Set
        End Property

        ''' <summary>
        ''' Time (second) before to have the right to cryptogram'reload  
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N157"), _
        LocalizableDescAtt("_D157"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CryptUseTimer() As Integer
            Get
                Return _CryptUseTimerInt
            End Get
            Set(ByVal value As Integer)
                If (value < 0) Then value = 0
                If (value > 60) Then value = 60
                _CryptUseTimerInt = Math.Round(value)
            End Set
        End Property

        ''' <summary>
        ''' cryptogram's pixel width 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N155"), _
        LocalizableDescAtt("_D155"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CryptWidth() As CssUnit
            Get
                Dim width = MyBase.StylesSkin.FindStylesZone("Cryptogram").BaseStyles.Width(True)
                If width Is Nothing OrElse width.GetNumber = 0 Then
                    width = New CssUnit()
                    width.Value = 150
                    width.Unit = CssEnum.Unit.pixel
                End If
                Return width
            End Get
            Set(ByVal value As CssUnit)
                MyBase.StylesSkin.FindStylesZone("Cryptogram").FindStyles(StylesZone.EnuStyleState.Normal).Width = value
            End Set
        End Property

        ''' <summary>
        ''' sensitive case or not (true, false)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N164"), _
        LocalizableDescAtt("_D164"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property DifUpLow() As Boolean
            Get
                Return _DifUpLow
            End Get
            Set(ByVal value As Boolean)
                _DifUpLow = value
            End Set
        End Property

        ''' <summary>
        ''' Noise: max number of aleatory circle
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Noise), _
        Ressource.localizable.LocalizableNameAtt("_N177"), _
        LocalizableDescAtt("_D177"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NbCircleMax() As Integer
            Get
                Return _NbCircleMax
            End Get
            Set(ByVal value As Integer)
                _NbCircleMax = value
            End Set
        End Property

        ''' <summary>
        ''' Noise: min number of aleatory circle
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Noise), _
        Ressource.localizable.LocalizableNameAtt("_N176"), _
        LocalizableDescAtt("_D176"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NbCircleMin() As Integer
            Get
                Return _NbCircleMin
            End Get
            Set(ByVal value As Integer)
                _NbCircleMin = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Noise), _
        Ressource.localizable.LocalizableNameAtt("_N178"), _
        LocalizableDescAtt("_D178"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NoiseColorChar() As EnuNoiseColorChar
            Get
                Return _NoiseColorChar
            End Get
            Set(ByVal value As EnuNoiseColorChar)
                _NoiseColorChar = value
            End Set
        End Property

        ''' <summary>
        ''' Noise: max number of aleatory lines
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Noise), _
        Ressource.localizable.LocalizableNameAtt("_N175"), _
        LocalizableDescAtt("_D175"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NoiseLineMax() As Integer
            Get
                Return _NoiseLineMax
            End Get
            Set(ByVal value As Integer)
                _NoiseLineMax = value
            End Set
        End Property

        ''' <summary>
        ''' Noise: min number of aleatory lines
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Noise), _
        Ressource.localizable.LocalizableNameAtt("_N174"), _
        LocalizableDescAtt("_D174"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NoiseLineMin() As Integer
            Get
                Return _NoiseLineMin
            End Get
            Set(ByVal value As Integer)
                _NoiseLineMin = value
            End Set
        End Property

        ''' <summary>
        '''  Noise: aleatory pixel max number
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Noise), _
        Ressource.localizable.LocalizableNameAtt("_N173"), _
        LocalizableDescAtt("_D173"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NoisePxMax() As Integer
            Get
                Return _NoisePxMax
            End Get
            Set(ByVal value As Integer)
                _NoisePxMax = value
            End Set
        End Property

        ''' <summary>
        ''' Noise: aleatory pixel min number
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Noise), _
        Ressource.localizable.LocalizableNameAtt("_N172"), _
        LocalizableDescAtt("_D172"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NoisePxMin() As Integer
            Get
                Return _NoisePxMin
            End Get
            Set(ByVal value As Integer)
                _NoisePxMin = value
            End Set
        End Property

        ''' <summary>
        '''noise it is above (true) or below (false) the writing  
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Noise), _
        Ressource.localizable.LocalizableNameAtt("_N180"), _
        LocalizableDescAtt("_D180"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NoiseUp() As Boolean
            Get
                Return _NoiseUp
            End Get
            Set(ByVal value As Boolean)
                _NoiseUp = value
            End Set
        End Property

        ''' <summary>
        ''' Error message displayed to the visitor
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N182"), _
        LocalizableDescAtt("_D182"), _
        TypeConverter(GetType(TConvLocalizableString)), _
        ExportVar(ExportVar.EnuVarType.All), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property TextError() As LocalizableHtml
            Get
                If _TextError Is Nothing Then _TextError = New LocalizableHtml(LocalizableOpen._0290)
                Return _TextError
            End Get
            Set(ByVal value As LocalizableHtml)
                _TextError = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
        Ressource.localizable.LocalizableNameAtt("_N163"), _
        LocalizableDescAtt("_D163"), _
        ExportVar(ExportVar.EnuVarType.Php), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Tfont() As Link
            Get
                If _Tfont Is Nothing Then _Tfont = New Link
                Return _Tfont
            End Get
            Set(ByVal value As Link)
                _Tfont = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0286
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupForm"
            info.ToolBoxIco = My.Resources.WECaptcha
            info.ToolBoxDescription = LocalizableOpen._0289
            info.ScriptVarName = "OEConfWECaptcha"
            Return info
        End Function

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.CreateAutoRessourceByFile(_Tfont, Link.EnuLinkType.Font, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ElementsLibrary\Common\Font\luggerbu.ttf"), "WEFiles/Font/luggerbu.ttf")
            MyBase.AddSharedScripts(EnuSharedScript.jQueryForm)
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WECaptcha.js", "WEFiles/Client/WECaptcha.js") ', False)
            MyBase.AddExternalScripts(EnuScriptType.Php, "ElementsLibrary\Common\Server\WECaptcha\WECaptcha.cfg.php", "WEFiles/Server/WECaptcha/WECaptcha.cfg.php")
            MyBase.AddExternalScripts(EnuScriptType.Php, "ElementsLibrary\Common\Server\WECaptcha\WECaptcha.fct.php", "WEFiles/Server/WECaptcha/WECaptcha.fct.php")
            MyBase.AddExternalScripts(EnuScriptType.Php, "ElementsLibrary\Common\Server\WECaptcha\WECaptcha.inc.php", "WEFiles/Server/WECaptcha/WECaptcha.inc.php")
            MyBase.AddExternalScripts(EnuScriptType.Php, "ElementsLibrary\Common\Server\WECaptcha\WECaptchabase.php", "WEFiles/Server/WECaptcha/WECaptchabase.php")
            MyBase.AddExternalScripts(EnuScriptType.Php, "ElementsLibrary\Common\Server\WECaptcha\WECaptcha.php", "WEFiles/Server/WECaptcha/WECaptcha.php")
            MyBase.OnInitExternalFiles()
        End Sub

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("Cryptogram", LocalizableOpen._0295, LocalizableOpen._0296))
            configStylesZones.Add(New ConfigStylesZone("Reload", LocalizableOpen._0297, LocalizableOpen._0298))
            configStylesZones.Add(New ConfigStylesZone("LeftInput", LocalizableOpen._0301, LocalizableOpen._0302))
            configStylesZones.Add(New ConfigStylesZone("RightInput", LocalizableOpen._0303, LocalizableOpen._0304))
            configStylesZones.Add(New ConfigStylesZone("Input", LocalizableOpen._0305, LocalizableOpen._0306))

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("LeftInput"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("span")

            writer.WriteBeginTag("input")
            writer.WriteAttribute("name", ID)
            writer.WriteAttribute("type", "text")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Input"))
            writer.Write(HtmlTextWriter.SelfClosingTagEnd)

            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("RightInput"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("span")

            If MyBase.Page.RenderMode <> Page.EnuTypeRenderMode.Export Then
                Call RenderEditorMode(writer)
            Else
                writer.WriteBeginTag("img")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Cryptogram"))
                writer.WriteAttribute("alt", "")
                writer.WriteAttribute("src", "")
                writer.Write(HtmlTextWriter.SelfClosingTagEnd)
                writer.WriteLine()
            End If

            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Reload"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("span")
            writer.WriteLine()

            MyBase.RenderEndTag(writer)
        End Sub

        Private Sub RenderEditorMode(ByVal writer As HtmlWriter)
            writer.WriteBeginTag("span")
            writer.WriteAttribute("style", String.Concat("display: inline-block; vertical-align:middle; width:", Me.CryptWidth.ToCss, ";height:", Me.CryptHeight.ToCss, "; background-color:#999999; color:#FFFFF; font-size :10px; font-family :Arial; text-align :center ;"))
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.Write(LocalizablePropertyDefaultValue._0016)
            writer.WriteEndTag("span")
        End Sub

        #End Region 'Methods

    End Class

End Namespace

