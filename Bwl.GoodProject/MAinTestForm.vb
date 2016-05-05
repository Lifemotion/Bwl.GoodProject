Imports System.Threading
Imports Bwl.Framework

Public Class MainTestForm
    Inherits FormAppBase
    ' Наследование от FormAppBase позволяет использовать конфиги и логины, а также добавляет на форму мены для вызова конфигов и компонент для отображения логов

    'C начала объявляем внутренние переменные класса

    ' внутренние переменные класса начинаем с подчеркивания, начальная буква первого слова маленькая, начальные буквы остальных слов большие
    ' из названия переменной должно быть понятно, за что она отвечает и для чего используется (самодокументированный код)
    ' внутренние члены класса должны быть закрыты от внешнего окружения (модификатор Private)
    Private _showDateTimeThread As Thread

    ' настройки делаем так
    Private _dateDateTimeStringFormat As StringSetting

    ' Далее описываем события
    Public Event EventExample(arg1 As String, arg2 As String)

    ' Далее идет конструктор
    Public Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        Dim formSetting = _storage.CreateChildStorage("FormSettings", "Настройки формы")
        _dateDateTimeStringFormat = formSetting.CreateStringSetting("DateDateTimeStringFormat", "HH:mm:ss dd.MM.yyyy", "Формат отображения ")

        _showDateTimeThread = New Thread(AddressOf ShowDateTimeThreadProc)
        _showDateTimeThread.Name = "ShowDateTimeThread" ' обязательно указываем имя потока
        _showDateTimeThread.IsBackground = True ' чтобы поток завершился автоматически при завершении приложения
        _showDateTimeThread.Start()
    End Sub

    ' Далее указываем свойства

    ' Далее идут функции

    ' открытые члены класса называем без подчеркивания сразу с большой буквы.
    ' из названия переменной должно быть понятно, за что она отвечает и для чего используется (самодокументированный код)
    ' названия аргументов процедуры или функции также должы однозначно описывать, что это за аргумент и для чего используется
    Public Sub SetDateTimeStringFormat(dateTimeStringFormat As String)
        _dateDateTimeStringFormat.Value = dateTimeStringFormat
    End Sub

    Public Sub ShowDateTimeThreadProc()
        Do
            Dim dt = Now
            Dim dtString = dt.ToString(_dateDateTimeStringFormat.Value)

            ' добавить вывод текста

            Thread.Sleep(50)
        Loop
    End Sub

End Class
