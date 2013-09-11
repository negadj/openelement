Imports System.Resources

Namespace Ressource.localizable

    ''' <summary>
    ''' Classe intermédiaire recherchant la ressource "catégorie de la propriété
    ''' </summary>
    ''' <remarks></remarks>
    <AttributeUsage(AttributeTargets.All)> _
    Public Class LocalizableCatAtt
        Inherits System.ComponentModel.CategoryAttribute

        ''' <summary>
        ''' Enum contenant la liste des catégories disponibles pour la classification des propriétés des éléments
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum EnumWECategory As Integer
            Appearance = 1
            Behavior = 2
            EditMode = 3
            Edition = 4
            settings = 5
            Expert = 6
            Noise = 7
            Characters = 8
            Automatique = 9
        End Enum

        ''' <summary>
        ''' Fichier de ressource associé
        ''' </summary>
        ''' <remarks></remarks>
        Private _ResourceManager As ResourceManager
        ''' <summary>
        ''' Enum associé à la ressource
        ''' </summary>
        ''' <remarks></remarks>
        Private _Category As EnumWECategory

        ''' <summary>
        ''' Constructeur simple 
        ''' </summary>
        ''' <param name="category">Category choisi</param>
        ''' <remarks>Il est impossible d'utiliser un autre fichier de ressource que celui par défaut fourni par l'equipe d'openElement</remarks>
        Public Sub New(ByVal category As EnumWECategory)
            MyBase.New()
            _ResourceManager = My.Resources.text.LocalizablePropertyCategory.ResourceManager
            _Category = category
        End Sub

 
        Public Overloads ReadOnly Property Category() As String
            Get
                Return GetLocalizedString(MyBase.Category)
            End Get
        End Property

        ''' <summary>
        ''' Retourne la valeur du champs localisé en fonction de l'enum choisi
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overrides Function GetLocalizedString(ByVal value As String) As String
            Try
                Select Case _Category
                    Case EnumWECategory.Appearance
                        value = "_01"
                    Case EnumWECategory.Behavior
                        value = "_03"
                    Case EnumWECategory.Edition
                        value = "_02"
                    Case EnumWECategory.EditMode
                        value = "_04"
                    Case EnumWECategory.settings
                        value = "_05"
                    Case EnumWECategory.Expert
                        value = "_06"
                    Case EnumWECategory.Noise
                        value = "_07"
                    Case EnumWECategory.Characters
                        value = "_08"
                    Case EnumWECategory.Automatique
                        value = "_09"
                    Case Else

                End Select

                Dim localizedDescription As String = _ResourceManager.GetString(value)
                If Not String.IsNullOrEmpty(localizedDescription) Then Return localizedDescription
            Catch ex As Exception
                Return String.Empty
            End Try
            Return String.Empty
        End Function

    End Class

End Namespace