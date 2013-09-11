Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.ElementWECommon.Stats.Forms

'Namespace de l'élément (Créer le votre ex : Elements.MyCompagny)
Namespace Elements.Stats

    ''' <summary>
    ''' L'élément présenté ci-dessous est la copie conforme du code source de l'élément Compteur disponible dans openElement
    ''' Créer une Class Public qui hérite de "openElement.WebElement.Elements.ElementBase".
    ''' Voir la documentation se rapportant à ElementBase pour toutes les explications des fonctions de mybase utilisé dans cette classe.
    ''' Le nom de la class est primordial il doit être unique pour le même Namespace et ne pourra plus être modifié par la suite.
    ''' Il est indispensable d'indiquer cette Class comme sérializable.
    ''' </summary>
    ''' <remarks>Il est préférable de nous soumettre le nom</remarks>
    <Serializable()> _
    Public Class WECounter
        Inherits ElementBase

#Region "Propriétés"
        'Pour les métaTags des propriétés publiques, se rapporter au chapitre concerné                                                                                                      InzM3t5itgmm

        ''' <summary>
        ''' Données de configuration du compteur. 
        ''' </summary>
        ''' <remarks></remarks>
        Private _Config As FrmCounterConfig.WECounterConfig

        ''' <summary>
        ''' Propriété de la variable _Config
        ''' </summary>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N001"), _
        Ressource.localizable.LocalizableDescAtt("_D001"), _
        Editor(GetType(Editors.UITypeCounter), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.ExportVar(Common.Attributes.ExportVar.EnuVarType.All), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Config() As FrmCounterConfig.WECounterConfig
            Get
                If _Config Is Nothing Then _Config = New FrmCounterConfig.WECounterConfig
                Return _Config
            End Get
            Set(ByVal value As FrmCounterConfig.WECounterConfig)
                _Config = value
            End Set
        End Property

#End Region

#Region "Constructeur"

        ''' <summary>
        ''' Le constructeur doit avoir obligatoirement la forme suivante et faire appel au constructeur de la classe hérité
        ''' Pour les paramètres du contructeur de base, se rapporter à la classe correspondante
        ''' </summary>
        ''' <param name="page">Référence à la page dans lequel est positionné l'élément(attribuer automatiquement)</param>
        ''' <param name="parentID">Identifiant du conteneur parent(attribuer automatiquement)</param>
        ''' <param name="templateName">Nom du template direct dans lequel est contenu l'élément(attribuer automatiquement)</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WECounter", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
            '1er initialisations des elements de configuration de base
            'Attention : il s'agit de valeur par défaut à la création de l'élément et non de valeur par défaut obligatoire
            Config.CountMethod = FrmCounterConfig.EnuMethodCounter.All
            Config.InitialValue = 0
            Config.TypeCounter = FrmCounterConfig.EnuTypeCounter.All
            Config.Lenght = 4

        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            'Nom de l'élément affiché dans la liste des éléments
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0026 '"Compteur de visites"
            'Description de l'élément
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0027 '"Afficher nombre de visiteurs de la page."
            'Numéro de version majeur de l'élément
            info.VersionMajor = 1
            'Numéro de version mineur de l'élément
            info.VersionMinor = 0
            'Groupe de la barre d'outils d'openElement 
            info.GroupName = "NBGroupStats"
            'Icone pour la barre d'outils d'openElement (Taille 16x16) 
            info.ToolBoxIco = My.Resources.WECounter
            'Propriété à ouvrir automatiquement lors de l'ajout de l'élément dans la page
            info.AutoOpenProperty = "Config"

            'Pour rajouter des propriétés dans la liste des acces rapides (icones qui s'affiche en dessous de l'élément lors de sa sélection): 
            'Ajouter à la liste un nouvel objet SortProperty 
            '(paramètres : nom de la propriété, nom de l'image associé (celle ci est placé dans le dossier ressource du projet), Texte du tooltip associé)
            info.SortPropertyList.Add(New SortProperty("Config", "tools.png", My.Resources.text.LocalizableOpen._0030)) '"Configuration"
            Return info

        End Function

        ''' <summary>
        ''' Evènement de démarrage (OnOpen) obligatoire pour la configuration de l'élément
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnOpen()


            'Pour rajouter une zone dans la liste des zone de style (permet l'édition d'un css spécifique à cette zone)
            '(paramètres : nom de la zone (sera utilisé dans le render) , titre de la zone affiché à l'utilisateur, description de la zone affiché à l'utilisateur, style de la zone (ici : affiché dans le ribbon et l'onglet style)
            Dim ConfigStylesZones As New List(Of StylesManager.ConfigStylesZone)
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Digit", My.Resources.text.LocalizableOpen._0028, My.Resources.text.LocalizableOpen._0029)) '"Chiffres" - "Permet de configurer chacun des chiffres du compteur de visites"


            'A placer obligatoirement à la fin
            MyBase.OnOpen(ConfigStylesZones)

        End Sub

        Protected Overrides Sub OnInitExternalFiles()
            'Pour rajouter au projet des fichiers associés, ainsi qu'à la page les liaison vers ces fichier : 
            'Attention tous les chemins doivent être relatif par rapport au dossier contenant les fichiers
            'ici ajout d'un fichier de type javascript (paramètres: type du fichier, chemin du fichier dans le projet openElement, chemin de destination du fichier copié dans le site internet)
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WECounter.js", "WEFiles/Client/WECounter.js")
            'ici ajout d'un fichier de type script php (paramètres: type du fichier, chemin du fichier dans le projet openElement, chemin de destination du fichier copié dans le site internet) 
            MyBase.AddExternalScripts(Common.EnuScriptType.Php, "ElementsLibrary\Common\Server\WECounter.php", "WEFiles/Server/WECounter.php")
            MyBase.OnInitExternalFiles()
        End Sub

#End Region

#Region "Render"
        'Région consacré au rendu html sur la page internet de l'objet 'compteur' (obligatoire pour les éléments de type EnuElementType.PageEdit).

        ''' <summary>
        ''' Evènement de rendu (obligatoire pour les éléments de type EnuElementType.PageEdit).
        ''' C'est ici que la création de l'HTML de l'élément se construit.
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)
            Dim initialValueLenght As Integer = Config.InitialValue.ToString.Length

            'A ajouter obligatoirement en début du rendu html de l'élement
            MyBase.RenderBeginTag(writer)

            'Vous avez à votre disposition trois périodes pour le render : 
            'Editor : écriture du rendu html pour la zone d'édition d'openElement,
            'Export : écriture du rendu html final, c'est celui qui sera sur les pages htm exportées lors de la mise en ligne
            'Preview : écriture du rendu html pour la page de prévisualisation.

            'Ici on n'écris le code html du compteur que pour le fichier final exporté lors de la mise en ligne (le code php associé ne s'execute qu'en ligne)
            If MyBase.Page.RenderMode <> openElement.WebElement.Page.EnuTypeRenderMode.Export Then
                For i = 1 To Me.Config.Lenght - initialValueLenght
                    Call DivRender(writer, "0")
                Next
                For i = 1 To Me.Config.Lenght
                    If initialValueLenght >= i Then Call DivRender(writer, Config.InitialValue.ToString.Chars(i - 1))
                Next
            End If
            'A ajouter obligatoirement en fin du rendu html de l'élement
            MyBase.RenderEndTag(writer)
        End Sub

        Private Sub DivRender(ByVal writer As Common.HtmlWriter, ByVal value As String)
            writer.WriteBeginTag("div")
            'Ajout de la zone de style déclarer dans la fonction 'OnOpen' 
            writer.WriteAttribute("class", GetStyleZoneClass("Digit"))
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.Write(value)
            writer.WriteEndTag("div")
            writer.WriteLine()
        End Sub


#End Region

    End Class

End Namespace
