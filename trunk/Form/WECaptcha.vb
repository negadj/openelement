Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.StylesManager
Imports System.Drawing
Imports openElement.WebElement.LinksManager

Namespace Elements.Form

    <Serializable(), openElement.WebElement.Common.Attributes.OEObsolete(1, 31)> _
    Public Class WECaptcha
        Inherits ElementBase

        ''' <summary>
        ''' Niveau de clarté des caractères si choix aléatoire (0->4)
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum Enu_CharColorRndLevel As Short
            ''' <summary>
            ''' Aucune sélection
            ''' </summary>
            ''' <remarks></remarks>
            None = 0
            ''' <summary>
            ''' Couleurs très sombres (surtout pour les fonds clairs)
            ''' </summary>
            ''' <remarks></remarks>
            VeryDark = 1
            ''' <summary>
            ''' Couleurs sombres
            ''' </summary>
            ''' <remarks></remarks>
            Dark = 2
            ''' <summary>
            ''' Couleurs claires
            ''' </summary>
            ''' <remarks></remarks>
            Light = 3
            ''' <summary>
            ''' Couleurs très claires (surtout pour fonds sombres)
            ''' </summary>
            ''' <remarks></remarks>
            VeryLight = 4

        End Enum

        ''' <summary>
        '''  Bruit: Couleur d'ecriture des pixels, lignes, cercles: 
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum Enu_NoiseColorChar As Short
            ''' <summary>
            ''' Couleur d'écriture des caractères
            ''' </summary>
            ''' <remarks></remarks>
            Same = 1
            ''' <summary>
            ''' Couleur aléatoire
            ''' </summary>
            ''' <remarks></remarks>
            Ramdom = 3
        End Enum

        Private _CryptWidth As CssItems.CssUnit
        Private _CryptHeight As CssItems.CssUnit

        Private _CharColor As Color
        Private _CharColorHex As String
        Private _CharColorRnd As Boolean
        Private _CharColorRndLevel As Enu_CharColorRndLevel
        Private _CharClear As Integer
        Private _Tfont As Link
        Private _Charel As String
        Private _DifUpLow As Boolean
        Private _CharNbMin As Integer
        Private _CharNbMax As Integer
        Private _CharSpace As CssItems.CssUnit
        Private _CharSizeMin As CssItems.CssFontSize
        Private _CharSizeMax As CssItems.CssFontSize
        Private _CharAngleMax As Integer
        Private _CharUp As Boolean
        Private _NoisePxMin As Integer
        Private _NoisePxMax As Integer
        Private _NoiseLineMin As Integer
        Private _NoiseLineMax As Integer
        Private _NbCircleMin As Integer
        Private _NbCircleMax As Integer
        Private _NoiseColorChar As Enu_NoiseColorChar
        Private _NoiseUp As Boolean
        Private _CryptUseTimer As Boolean ' obsolete (erreur de type)
        Private _CryptUseTimerInt As Integer ' correct
        Private _CryptUseMax As Integer
        Private _TextCaptcha As DataType.LocalizableHtml
        Private _TextError As DataType.LocalizableHtml



#Region "Proprietes globale"



        ''' <summary>
        ''' Texte de l'imput
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
         Public Property TextCaptcha() As DataType.LocalizableHtml
            Get
                If _TextCaptcha Is Nothing Then _TextCaptcha = New DataType.LocalizableHtml(My.Resources.text.LocalizableOpen._0291) '"Recopier le code ci-dessus :"
                Return _TextCaptcha
            End Get
            Set(ByVal value As DataType.LocalizableHtml)
                _TextCaptcha = value
            End Set
        End Property

        ''' <summary>
        ''' Message d'erreur
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
     Ressource.localizable.LocalizableNameAtt("_N182"), _
     Ressource.localizable.LocalizableDescAtt("_D182"), _
     TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
     Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.All), _
     Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
     Public Property TextError() As DataType.LocalizableHtml
            Get
                If _TextError Is Nothing Then _TextError = New DataType.LocalizableHtml(My.Resources.text.LocalizableOpen._0290) '"Une erreur est survenue dans le Captcha. \n Veuillez réessayer utltérieurment."
                Return _TextError
            End Get
            Set(ByVal value As DataType.LocalizableHtml)
                _TextError = value
            End Set
        End Property

        ''' <summary>
        ''' Largeur du cryptogramme (en pixels)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N155"), _
        Ressource.localizable.LocalizableDescAtt("_D155"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CryptWidth() As CssItems.CssUnit
            Get
                Dim width = MyBase.StylesSkin.FindStylesZone("Cryptogram").BaseStyles.Width(True)
                If width Is Nothing OrElse width.GetNumber = 0 Then
                    width = New CssItems.CssUnit()
                    width.Value = 150
                    width.Unit = CssItems.CssEnum.Unit.pixel
                End If
                Return width
            End Get
            Set(ByVal value As CssItems.CssUnit)
                MyBase.StylesSkin.FindStylesZone("Cryptogram").FindStyles(StylesManager.StylesZone.EnuStyleState.Normal).Width = value
            End Set
        End Property

        ''' <summary>
        ''' Hauteur du cryptogramme (en pixels)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N156"), _
        Ressource.localizable.LocalizableDescAtt("_D156"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CryptHeight() As CssItems.CssUnit
            Get
                Dim height = MyBase.StylesSkin.FindStylesZone("Cryptogram").BaseStyles.Height(True)
                If height Is Nothing OrElse height.GetNumber = 0 Then
                    height = New CssItems.CssUnit()
                    height.Value = 30
                    height.Unit = CssItems.CssEnum.Unit.pixel
                End If
                Return height
            End Get
            Set(ByVal value As CssItems.CssUnit)
                MyBase.StylesSkin.FindStylesZone("Cryptogram").FindStyles(StylesManager.StylesZone.EnuStyleState.Normal).Height = value
            End Set
        End Property

        ''' <summary>
        ''' Temps (en seconde) avant d'avoir le droit de regénérer un cryptogramme
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
       Ressource.localizable.LocalizableNameAtt("_N157"), _
       Ressource.localizable.LocalizableDescAtt("_D157"), _
       Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
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
        ''' Nb maximum de fois que l'utilisateur peut générer le cryptogramme
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
       Ressource.localizable.LocalizableNameAtt("_N158"), _
       Ressource.localizable.LocalizableDescAtt("_D158"), _
       Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CryptUseMax() As Integer
            Get
                Return _CryptUseMax
            End Get
            Set(ByVal value As Integer)
                _CryptUseMax = value
            End Set
        End Property
#End Region


#Region "Proprietes Char"
        ''' <summary>
        ''' Caractères autorisés
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' DD maintenant, ce propriete est ignore dans PHP, a cause de $crypteasy = true; dans .cfg.php, et tout le monde ( = Yannic) est confondu..
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
        ''' Couleur de base des caractères
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
       Ressource.localizable.LocalizableNameAtt("_N159"), _
       Ressource.localizable.LocalizableDescAtt("_D159"), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
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
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php)> _
        Public Property CharColorHex() As String
            Get
                Return _CharColorHex
            End Get
            Set(ByVal value As String)
                _CharColorHex = value
            End Set
        End Property



        ''' <summary>
        ''' Choix aléatoire de la couleur.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
       Ressource.localizable.LocalizableNameAtt("_N160"), _
       Ressource.localizable.LocalizableDescAtt("_D160"), _
       Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CharColorRnd() As Boolean
            Get
                Return _CharColorRnd
            End Get
            Set(ByVal value As Boolean)
                _CharColorRnd = value
            End Set
        End Property

        ''' <summary>
        ''' Niveau de clarté des caractères si choix aléatoire (0->4)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
       Ressource.localizable.LocalizableNameAtt("_N161"), _
       Ressource.localizable.LocalizableDescAtt("_D161"), _
       TypeConverter(GetType(Editors.Converter.TConvEnuCharColorRndLevel)), _
       Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CharColorRndLevel() As Enu_CharColorRndLevel
            Get
                Return _CharColorRndLevel
            End Get
            Set(ByVal value As Enu_CharColorRndLevel)
                _CharColorRndLevel = value
            End Set
        End Property

        ''' <summary>
        ''' Intensité de la transparence des caractères (0->127)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
       Ressource.localizable.LocalizableNameAtt("_N162"), _
       Ressource.localizable.LocalizableDescAtt("_D162"), _
       Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
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

        ''' <summary>
        ''' Police des caractères
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
       Ressource.localizable.LocalizableNameAtt("_N163"), _
       Ressource.localizable.LocalizableDescAtt("_D163"), _
       Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Tfont() As Link
            Get
                If _Tfont Is Nothing Then _Tfont = New Link
                Return _Tfont
            End Get
            Set(ByVal value As Link)
                _Tfont = value
            End Set
        End Property

        ''' <summary>
        ''' Différencie les Maj/Min lors de la saisie du code (true, false)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
       Ressource.localizable.LocalizableNameAtt("_N164"), _
       Ressource.localizable.LocalizableDescAtt("_D164"), _
       Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property DifUpLow() As Boolean
            Get
                Return _DifUpLow
            End Get
            Set(ByVal value As Boolean)
                _DifUpLow = value
            End Set
        End Property

        ''' <summary>
        ''' Nb minimum de caracteres dans le cryptogramme
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
       Ressource.localizable.LocalizableNameAtt("_N165"), _
       Ressource.localizable.LocalizableDescAtt("_D165"), _
       Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CharNbMin() As Integer
            Get
                Return _CharNbMin
            End Get
            Set(ByVal value As Integer)
                If value < 4 Then value = 4
                _CharNbMin = value
            End Set
        End Property

        ''' <summary>
        ''' Nb maximum de caracteres dans le cryptogramme
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
      Ressource.localizable.LocalizableNameAtt("_N166"), _
      Ressource.localizable.LocalizableDescAtt("_D166"), _
      Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
      Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
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
        ''' Espace entre les caracteres (en pixels)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
      Ressource.localizable.LocalizableNameAtt("_N167"), _
      Ressource.localizable.LocalizableDescAtt("_D167"), _
      Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
      Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CharSpace() As CssItems.CssUnit
            Get
                If _CharSpace Is Nothing Then _CharSpace = New CssItems.CssUnit
                Return _CharSpace
            End Get
            Set(ByVal value As CssItems.CssUnit)
                _CharSpace = value
            End Set
        End Property

        ''' <summary>
        ''' Taille minimum des caractères
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
     Ressource.localizable.LocalizableNameAtt("_N168"), _
     Ressource.localizable.LocalizableDescAtt("_D168"), _
     Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
     Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
       Public Property CharSizeMin() As CssItems.CssFontSize
            Get
                If _CharSizeMin Is Nothing Then _CharSizeMin = New CssItems.CssFontSize
                Return _CharSizeMin
            End Get
            Set(ByVal value As CssItems.CssFontSize)
                If value.Size.Value > CharSizeMax.Size.Value Then CharSizeMax = value
                _CharSizeMin = value
            End Set
        End Property

        ''' <summary>
        ''' Taille maximum des caractères
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
         Ressource.localizable.LocalizableNameAtt("_N169"), _
         Ressource.localizable.LocalizableDescAtt("_D169"), _
         Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
         Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CharSizeMax() As CssItems.CssFontSize
            Get
                If _CharSizeMax Is Nothing Then _CharSizeMax = New CssItems.CssFontSize
                Return _CharSizeMax
            End Get
            Set(ByVal value As CssItems.CssFontSize)
                If value.Size.Value < CharSizeMin.Size.Value Then CharSizeMin = value
                _CharSizeMax = value
            End Set
        End Property

        ''' <summary>
        ''' Angle maximum de rotation des caracteres (0-360)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
        Ressource.localizable.LocalizableNameAtt("_N170"), _
        Ressource.localizable.LocalizableDescAtt("_D170"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
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
        ''' Déplacement vertical aléatoire des caractères (true/false)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Characters), _
        Ressource.localizable.LocalizableNameAtt("_N171"), _
        Ressource.localizable.LocalizableDescAtt("_D171"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property CharUp() As Boolean
            Get
                Return _CharUp
            End Get
            Set(ByVal value As Boolean)
                _CharUp = value
            End Set
        End Property
#End Region

#Region "Proprietes noise"

        ''' <summary>
        ''' Bruit: Nb minimum de pixels aléatoires
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Noise), _
      Ressource.localizable.LocalizableNameAtt("_N172"), _
      Ressource.localizable.LocalizableDescAtt("_D172"), _
      Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
      Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
       Public Property NoisePxMin() As Integer
            Get
                Return _NoisePxMin
            End Get
            Set(ByVal value As Integer)
                _NoisePxMin = value
            End Set
        End Property

        ''' <summary>
        ''' Bruit: Nb maximum de pixels aléatoires
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Noise), _
        Ressource.localizable.LocalizableNameAtt("_N173"), _
        Ressource.localizable.LocalizableDescAtt("_D173"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NoisePxMax() As Integer
            Get
                Return _NoisePxMax
            End Get
            Set(ByVal value As Integer)
                _NoisePxMax = value
            End Set
        End Property

        ''' <summary>
        ''' Bruit: Nb minimum de lignes aléatoires
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Noise), _
        Ressource.localizable.LocalizableNameAtt("_N174"), _
        Ressource.localizable.LocalizableDescAtt("_D174"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NoiseLineMin() As Integer
            Get
                Return _NoiseLineMin
            End Get
            Set(ByVal value As Integer)
                _NoiseLineMin = value
            End Set
        End Property

        ''' <summary>
        ''' Bruit: Nb maximum de lignes aléatoires
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Noise), _
        Ressource.localizable.LocalizableNameAtt("_N175"), _
        Ressource.localizable.LocalizableDescAtt("_D175"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NoiseLineMax() As Integer
            Get
                Return _NoiseLineMax
            End Get
            Set(ByVal value As Integer)
                _NoiseLineMax = value
            End Set
        End Property

        ''' <summary>
        ''' Bruit: Nb minimum de cercles aléatoires 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Noise), _
        Ressource.localizable.LocalizableNameAtt("_N176"), _
        Ressource.localizable.LocalizableDescAtt("_D176"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NbCircleMin() As Integer
            Get
                Return _NbCircleMin
            End Get
            Set(ByVal value As Integer)
                _NbCircleMin = value
            End Set
        End Property

        ''' <summary>
        ''' Bruit: Nb maximim de cercles aléatoires
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Noise), _
        Ressource.localizable.LocalizableNameAtt("_N177"), _
        Ressource.localizable.LocalizableDescAtt("_D177"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NbCircleMax() As Integer
            Get
                Return _NbCircleMax
            End Get
            Set(ByVal value As Integer)
                _NbCircleMax = value
            End Set
        End Property

        ''' <summary>
        ''' Bruit: Couleur d'ecriture des pixels, lignes, cercles:
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Noise), _
        Ressource.localizable.LocalizableNameAtt("_N178"), _
        Ressource.localizable.LocalizableDescAtt("_D178"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NoiseColorChar() As Enu_NoiseColorChar
            Get
                Return _NoiseColorChar
            End Get
            Set(ByVal value As Enu_NoiseColorChar)
                _NoiseColorChar = value
            End Set
        End Property

        ''' <summary>
        ''' Le bruit est-il par dessus l'ecriture (coché) ou en dessous 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Noise), _
        Ressource.localizable.LocalizableNameAtt("_N180"), _
        Ressource.localizable.LocalizableDescAtt("_D180"), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.Php), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NoiseUp() As Boolean
            Get
                Return _NoiseUp
            End Get
            Set(ByVal value As Boolean)
                _NoiseUp = value
            End Set
        End Property
#End Region






        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WECaptcha", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.Width

            CharColor = Color.Black
            CharColorRnd = True
            CharColorRndLevel = Enu_CharColorRndLevel.Light

            CharClear = False ' DD this property is Boolean (even if _CharClear is Integer), and php code is adapted accordingly
            ' (si on le change a Integer, ca peut mettre les projets sauvegarde en danger; et en tout cas, c'est pas vraiment necessaire, cmaintenant c'est soit opaque, soit demi-transparente)

            Tfont = New Link()


            Charel = "ABCDEFGHKLMNPRTWXYZ234569"
            DifUpLow = False
            CharNbMin = 4
            CharNbMax = 6
            CharSpace.Value = 20
            CharSizeMin.Size.Value = 14
            CharSizeMax.Size.Value = 15
            CharAngleMax = 25
            CharColorRndLevel = Enu_CharColorRndLevel.Dark
            CharUp = True
            NoisePxMin = 10
            NoisePxMax = 20
            NoiseLineMin = 5
            NoiseLineMax = 10
            NbCircleMin = 2
            NbCircleMax = 4
            NoiseColorChar = Enu_NoiseColorChar.Same
            NoiseUp = False
            CryptUseTimer = 0
            CryptUseMax = 1000
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0286 ' "Captcha"
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupForm"
            info.ToolBoxIco = My.Resources.WECaptcha
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0289 ' "Ajouter un captcha permet d'éviter les envois automatique par des robots (spam)" 
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Cryptogram", My.Resources.text.LocalizableOpen._0295, My.Resources.text.LocalizableOpen._0296)) ' "Cryptogramme"
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Reload", My.Resources.text.LocalizableOpen._0297, My.Resources.text.LocalizableOpen._0298)) ' "Rechargement"
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Label", My.Resources.text.LocalizableOpen._0299, My.Resources.text.LocalizableOpen._0300)) '"Texte"
            configStylesZones.Add(New StylesManager.ConfigStylesZone("LeftInput", My.Resources.text.LocalizableOpen._0301, My.Resources.text.LocalizableOpen._0302)) '"Gauche du champ de saisie"
            configStylesZones.Add(New StylesManager.ConfigStylesZone("RightInput", My.Resources.text.LocalizableOpen._0303, My.Resources.text.LocalizableOpen._0304)) '"Droite du champ de saisie"
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Input", My.Resources.text.LocalizableOpen._0305, My.Resources.text.LocalizableOpen._0306)) '"Champ de saisie"

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.CreateAutoRessourceByFile(_Tfont, Link.EnuLinkType.Font, IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ElementsLibrary\Common\Font\luggerbu.ttf"), "WEFiles/Font/luggerbu.ttf")
            MyBase.AddSharedScripts(Common.EnuSharedScript.jQueryForm)
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WECaptcha.js", "WEFiles/Client/WECaptcha.js") ', False)
            MyBase.AddExternalScripts(Common.EnuScriptType.Php, "ElementsLibrary\Common\Server\WECaptcha\WECaptcha.cfg.php", "WEFiles/Server/WECaptcha/WECaptcha.cfg.php")
            MyBase.AddExternalScripts(Common.EnuScriptType.Php, "ElementsLibrary\Common\Server\WECaptcha\WECaptcha.fct.php", "WEFiles/Server/WECaptcha/WECaptcha.fct.php")
            MyBase.AddExternalScripts(Common.EnuScriptType.Php, "ElementsLibrary\Common\Server\WECaptcha\WECaptcha.inc.php", "WEFiles/Server/WECaptcha/WECaptcha.inc.php")
            MyBase.AddExternalScripts(Common.EnuScriptType.Php, "ElementsLibrary\Common\Server\WECaptcha\WECaptchabase.php", "WEFiles/Server/WECaptcha/WECaptchabase.php")
            MyBase.AddExternalScripts(Common.EnuScriptType.Php, "ElementsLibrary\Common\Server\WECaptcha\WECaptcha.php", "WEFiles/Server/WECaptcha/WECaptcha.php")
            MyBase.OnInitExternalFiles()
        End Sub

        ''' <summary>
        ''' Render général
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)
            MyBase.RenderBeginTag(writer)



            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Label"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

            'MyBase.RenderBeginTextEdit(writer, "TextCaptcha", False, False, False, "")
            'writer.Write(Me.TextCaptcha.GetHtmlValue(Me, "TextCaptcha"))
            'MyBase.RenderEndTextEdit(writer)

            writer.WriteHtmlBlockEdit(Me, "TextCaptcha", False)

            writer.WriteEndTag("span")
            writer.WriteLine()

            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("LeftInput"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("span")

            writer.WriteBeginTag("input")
            writer.WriteAttribute("name", ID)
            writer.WriteAttribute("type", "text")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Input"))
            writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)

            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("RightInput"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("span")

            If MyBase.Page.RenderMode <> openElement.WebElement.Page.EnuTypeRenderMode.Export Then
                Call RenderEditorMode(writer)
            Else
                writer.WriteBeginTag("img")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Cryptogram"))
                writer.WriteAttribute("alt", "")
                writer.WriteAttribute("src", "")
                writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)
                writer.WriteLine()
            End If

            writer.WriteBeginTag("span")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Reload"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("span")
            writer.WriteLine()


            MyBase.RenderEndTag(writer)
        End Sub

        ''' <summary>
        ''' render editeur
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <remarks></remarks>
        Private Sub RenderEditorMode(ByVal writer As Common.HtmlWriter)

            'Affichage Si aucun fichier selectionné et dans l'editeur
            writer.WriteBeginTag("span")
            'writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Cryptogram"))
            writer.WriteAttribute("style", String.Concat("display: inline-block; vertical-align:middle; width:", Me.CryptWidth.ToCss, ";height:", Me.CryptHeight.ToCss, "; background-color:#999999; color:#FFFFF; font-size :10px; font-family :Arial; text-align :center ;"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.Write(My.Resources.text.LocalizablePropertyDefaultValue._0016)
            writer.WriteEndTag("span")
        End Sub



    End Class

End Namespace

