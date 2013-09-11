Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.DB.DBElem


'Namespace de l'élément (Créer le votre ex : Elements.MyCompagny)
Namespace Elements.Standard


    ''' <summary>
    ''' L'élément présenté ci-dessous est la copie conforme du code source du label disponible dans openElement
    ''' Créer une Class Public qui hérite de "openElement.WebElement.Elements.ElementBase".
    ''' Le nom de la class est primordial il doit être unique pour le même Namespace et ne pourra plus être modifier par la suite.
    ''' Indiquer aussi que cette Class est sérializable.
    ''' </summary>
    ''' <remarks>Il est préférable de nous soumettre le nom</remarks>
    <Serializable()> _
    Public Class WELabel
        Inherits ElementBaseTextIcon

        Public Enum EnuBaliseH As Integer
            none = 0
            H1 = 1
            H2 = 2
            H3 = 3
            H4 = 4
            H5 = 5
            H6 = 6
        End Enum

        ''' <summary>
        ''' Création d'une variable privé qui sera enregistré lors de la sauvegarde de la page puis rechargé à l'ouverture.
        ''' </summary>
        ''' <remarks>Pour ne pas enregistrer utiliser l'attribut NonSerialized</remarks>
        <Common.Attributes.ContainsLinks()> _
        Private _Text As DataType.LocalizableHtml

        Private _BaliseHx As EnuBaliseH

        ''' <summary>
        ''' Le constructeur doit avoir obligatoirement la forme suivante
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            '1er paramètre (Type d'élément), 2ème nom unique (généralement nom de la class) puis (Page, ParentID, TemplateName)
            MyBase.New(EnuElementType.PageEdit, "WELabel", page, parentID, templateName)
            'Mode de redimentionnement par default
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            'Nom de l'élément affiché dans la liste des éléments
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0005 '"Texte simple ligne"
            'Description de l'élément
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0006 '"Ajouter un texte simple ligne."
            'Numéro de version majeur de l'élément
            info.VersionMajor = 2
            'Numéro de version mineur de l'élément
            info.VersionMinor = 0
            'Groupe de la barre d'outils d'openElement (NBGroupStandard,)
            info.GroupName = "NBGroupStandard"
            'Icone pour la barre d'outils d'openElement (Taille 16x16)
            info.ToolBoxIco = My.Resources.WELabel
            Return info

        End Function


        ''' <summary>
        ''' Evènement de démarrage (OnOpen) obligatoire pour la configuration de l'élément
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Text", My.Resources.text.LocalizableOpen._0300, My.Resources.text.LocalizableOpen._0300)) '"Zone de textes"

            'Indique le nom de la zone pour ElementBaseTextIcon
            MyBase.TextIconZoneName = "Text"

            'A placer obligatoirement à la fin
            MyBase.OnOpen(configStylesZones)

        End Sub

        ''' <summary>
        ''' Propriété de la variable local "_Text"
        ''' Faire un test si nothing puis création de l'Objet
        ''' Browsable(False) dans cette situation indique que la propriété n'est pas éditable directement sur les propriétés de l'élément.
        ''' Voir les différents "DataType" disponible sur l'aide
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        Public Property Text() As DataType.LocalizableHtml
            Get
                If _Text Is Nothing Then _Text = New DataType.LocalizableHtml(My.Resources.text.LocalizablePropertyDefaultValue._0002) 'Mon texte simple")
                Return _Text
            End Get
            Set(ByVal value As DataType.LocalizableHtml)
                _Text = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Expert), _
         Ressource.localizable.LocalizableNameAtt("_N154"), _
         Ressource.localizable.LocalizableDescAtt("_D154"), _
         TypeConverter(GetType(Elements.Standard.Editors.Converter.TConvEnuBaliseH)), _
         Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property BaliseHx() As EnuBaliseH
            Get
                Return _BaliseHx
            End Get
            Set(ByVal value As EnuBaliseH)
                _BaliseHx = value
            End Set
        End Property

        ''' <summary>
        ''' Evènement de rendu (obligatoire pour les éléments de type EnuElementType.PageEdit).
        ''' C'est ici que la création de l'HTML de l'élément se construit.
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            'A ajouter obligatoirement en début
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
                writer.Write(Web.UI.HtmlTextWriter.TagRightChar)
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

            'A ajouter obligatoirement en fin
            MyBase.RenderEndTag(writer)

        End Sub


#Region "DD Translation of LocalizableStrings"

        ' See comments in ElementBase class
        Public Overrides Function GetLocalizableStringsForTranslationSystem( _
                                        ByVal accListLS As Dictionary(Of String, DataType.LocalizableString), _
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

#End Region


    End Class

End Namespace



