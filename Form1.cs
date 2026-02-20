using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyCalculator
{
    public partial class Form1 : Form
    {
        // === КАЛЬКУЛЯТОР ===
        double firstNumber = 0;
        double secondNumber = 0;
        string operation = "";
        bool isOperatorPressed = false;
        private Dictionary<string, double> variables = new Dictionary<string, double>();

        // === ИНТЕРФЕЙС ===
        private TextBox displayBox;
        private Button[] buttons;
        private Label statusLabel;
        private ComboBox themeComboBox;
        private ComboBox languageComboBox;
        private MenuStrip menuStrip;
        private TabControl mainTabs;

        // === ЯЗЫКИ ===
        private string currentLanguage = "English";
        private Dictionary<string, Dictionary<string, string>> languages = new Dictionary<string, Dictionary<string, string>>
        {
            { "English", new Dictionary<string, string>
            {
                {"Title", "🎲Just Shitty Calculator"},
                {"TabCalculator", "🔢 Calculator"},
                {"TabFun", "🎲 Entertainment"},
                {"TabAbout", "ℹ️ About"},
                {"MenuFile", "File"},
                {"MenuExit", "Exit"},
                {"MenuTheme", "Theme"},
                {"MenuFun", "🎲 Entertainment"},
                {"MenuRollDice", "🎲 Roll Dice"},
                {"MenuFortune", "🔮 Fortune Cookie"},
                {"MenuColor", "🎨 Random Color"},
                {"MenuNewGame", "🎮 New Game"},
                {"MenuMelody", "🎵 Play Melody"},
                {"MenuLanguage", "🌐 Language"},
                {"StatusVariables", "Variables: none"},
                {"BtnVar", "Var"},
                {"BtnMem", "Mem"},
                {"GroupDice", "🎲 Roll Dice"},
                {"BtnRoll", "🎲 Roll!"},
                {"GroupFortune", "🔮 Fortune Cookie"},
                {"BtnFortune", "🥠 Get Fortune"},
                {"GroupColor", "🎨 Random Color"},
                {"BtnColor", "🎨 New Color"},
                {"GroupGuess", "🎮 Guess Number (1-100)"},
                {"BtnCheck", "Check"},
                {"BtnNewGame", "🔄 New Game"},
                {"GroupPiano", "🎵 Mini Piano (click)"},
                {"MsgVarSaved", "Variable {0} = {1} saved!"},
                {"MsgVarError", "Invalid format! Use: a=5"},
                {"MsgVarFormat", "Format: one letter = number (example: x=10)"},
                {"MsgVarInfo", "To save variable enter: letter=number\nExample: a=5"},
                {"MsgNoVars", "No saved variables"},
                {"MsgVarsTitle", "Variables"},
                {"MsgVarNotFound", "Variable '{0}' not found!"},
                {"MsgError", "Error"},
                {"MsgSuccess", "Success"},
                {"MsgInfo", "Information"},
                {"MsgDivZero", "Cannot divide by zero!"},
                {"MsgCalcError", "Calculation error: {0}"},
                {"MsgWin", "🎉 WIN! Number {0} in {1} attempts!"},
                {"MsgTooLow", "📈 Too low! Attempt #{0}"},
                {"MsgTooHigh", "📉 Too high! Attempt #{0}"},
                {"MsgEnterNumber", "❌ Enter number 1-100"},
                {"MsgMelody", "🎵 Tru-lu-lu! Melody played 🎶"},
                {"MsgMelodyTitle", "Music"},
                {"LblDiceResult", "🎲 Rolled: "},
                {"LblGuessStart", "I guessed a number 1-100. Try to guess! 🤔"},
                {"AboutText", @"🎲 CALCULATOR+ v2.0

🔢 MAIN FUNCTIONS:
• Basic calculations (+ - * /)
• Variables: a=5 → Var
• 5 themes
• 2 languages (EN/RU)

🎲 ENTERTAINMENT:
1. 🎲 Dice - roll virtual dice
2. 🔮 Fortune - random predictions
3. 🎨 Colors - random color generator with HEX
4. 🎮 Guess Number - logic mini-game
5. 🎵 Piano - play simple melody

💡 TIPS:
• Switch between tabs
• Change theme in menu or ComboBox
• Use keyboard for input
• Change language anytime

Made with ❤️ in C#"}
            }},
            { "Russian", new Dictionary<string, string>
            {
                {"Title", "🎲Just Shitty Calculator"},
                {"TabCalculator", "🔢 Калькулятор"},
                {"TabFun", "🎲 Развлечения"},
                {"TabAbout", "ℹ️ О программе"},
                {"MenuFile", "Файл"},
                {"MenuExit", "Выход"},
                {"MenuTheme", "Тема"},
                {"MenuFun", "🎲 Развлечения"},
                {"MenuRollDice", "🎲 Бросить кубик"},
                {"MenuFortune", "🔮 Печенье с предсказанием"},
                {"MenuColor", "🎨 Случайный цвет"},
                {"MenuNewGame", "🎮 Новая игра"},
                {"MenuMelody", "🎵 Сыграть мелодию"},
                {"MenuLanguage", "🌐 Язык"},
                {"StatusVariables", "Переменные: нет"},
                {"BtnVar", "Var"},
                {"BtnMem", "Mem"},
                {"GroupDice", "🎲 Бросить кубик"},
                {"BtnRoll", "🎲 Бросить!"},
                {"GroupFortune", "🔮 Печенье с предсказанием"},
                {"BtnFortune", "🥠 Получить предсказание"},
                {"GroupColor", "🎨 Случайный цвет"},
                {"BtnColor", "🎨 Новый цвет"},
                {"GroupGuess", "🎮 Угадай число (1-100)"},
                {"BtnCheck", "Проверить"},
                {"BtnNewGame", "🔄 Новая игра"},
                {"GroupPiano", "🎵 Мини-пианино (кликните)"},
                {"MsgVarSaved", "Переменная {0} = {1} сохранена!"},
                {"MsgVarError", "Неверный формат! Используйте: a=5"},
                {"MsgVarFormat", "Формат: одна буква = число (пример: x=10)"},
                {"MsgVarInfo", "Для сохранения переменной введите: буква=число\nПример: a=5"},
                {"MsgNoVars", "Нет сохраненных переменных"},
                {"MsgVarsTitle", "Переменные"},
                {"MsgVarNotFound", "Переменная '{0}' не найдена!"},
                {"MsgError", "Ошибка"},
                {"MsgSuccess", "Успех"},
                {"MsgInfo", "Информация"},
                {"MsgDivZero", "На ноль делить нельзя!"},
                {"MsgCalcError", "Ошибка вычисления: {0}"},
                {"MsgWin", "🎉 ПОБЕДА! Число {0} за {1} попыток!"},
                {"MsgTooLow", "📈 Слишком мало! Попытка #{0}"},
                {"MsgTooHigh", "📉 Слишком много! Попытка #{0}"},
                {"MsgEnterNumber", "❌ Введите число от 1 до 100"},
                {"MsgMelody", "🎵 Трю-лю-лю! Мелодия сыграна 🎶"},
                {"MsgMelodyTitle", "Музыка"},
                {"LblDiceResult", "🎲 Выпало: "},
                {"LblGuessStart", "Я загадал число от 1 до 100. Попробуйте угадать! 🤔"},
                {"AboutText", @"🎲 КАЛЬКУЛЯТОР+ v2.0

🔢 ОСНОВНЫЕ ФУНКЦИИ:
• Обычные вычисления (+ - * /)
• Переменные: a=5 → Var
• 5 тем оформления
• 2 языка (EN/RU)

🎲 РАЗВЛЕЧЕНИЯ:
1. 🎲 Кубик - бросайте виртуальный кубик
2. 🔮 Печенье - случайные предсказания
3. 🎨 Цвета - генератор случайных цветов с HEX
4. 🎮 Угадай число - мини-игра на логику
5. 🎵 Пианино - сыграйте простую мелодию

💡 СОВЕТЫ:
• Переключайтесь между вкладками
• Меняйте тему в меню или ComboBox
• Используйте клавиатуру для ввода
• Меняйте язык в любое время

Создано с ❤️ на C#"}
            }}
        };

        // === ТЕМЫ ===
        private string currentTheme = "Light";
        private Dictionary<string, ThemeColors> themes = new Dictionary<string, ThemeColors>
        {
            { "Light", new ThemeColors { 
                Background = Color.White, 
                Foreground = Color.Black, 
                DisplayBackground = Color.White, 
                DisplayForeground = Color.Black, 
                NumberButtonBack = Color.White, 
                NumberButtonFore = Color.Black, 
                OperatorButtonBack = Color.LightGray, 
                OperatorButtonFore = Color.Black, 
                ActionButtonBack = Color.Orange, 
                ActionButtonFore = Color.Black, 
                SpecialButtonBack = Color.LightBlue, 
                SpecialButtonFore = Color.Black, 
                BorderColor = Color.Gray,
                TabBackground = Color.White,
                TabForeground = Color.Black,
                MenuDropdownBack = Color.White,
                GroupBoxFore = Color.Black,
                ComboBoxDropdownBack = Color.White
            }},
            { "Dark", new ThemeColors { 
                Background = Color.FromArgb(30, 30, 30), 
                Foreground = Color.White, 
                DisplayBackground = Color.FromArgb(50, 50, 50), 
                DisplayForeground = Color.White, 
                NumberButtonBack = Color.FromArgb(60, 60, 60), 
                NumberButtonFore = Color.White, 
                OperatorButtonBack = Color.FromArgb(80, 80, 80), 
                OperatorButtonFore = Color.White, 
                ActionButtonBack = Color.FromArgb(255, 140, 0), 
                ActionButtonFore = Color.White, 
                SpecialButtonBack = Color.FromArgb(70, 130, 180), 
                SpecialButtonFore = Color.White, 
                BorderColor = Color.FromArgb(100, 100, 100),
                TabBackground = Color.FromArgb(40, 40, 40),
                TabForeground = Color.White,
                MenuDropdownBack = Color.FromArgb(50, 50, 50),
                GroupBoxFore = Color.White,
                ComboBoxDropdownBack = Color.FromArgb(50, 50, 50)
            }},
            { "Blue", new ThemeColors { 
                Background = Color.FromArgb(230, 240, 255), 
                Foreground = Color.FromArgb(0, 50, 100), 
                DisplayBackground = Color.White, 
                DisplayForeground = Color.FromArgb(0, 50, 100), 
                NumberButtonBack = Color.White, 
                NumberButtonFore = Color.FromArgb(0, 50, 100), 
                OperatorButtonBack = Color.FromArgb(100, 150, 200), 
                OperatorButtonFore = Color.White, 
                ActionButtonBack = Color.FromArgb(0, 100, 200), 
                ActionButtonFore = Color.White, 
                SpecialButtonBack = Color.FromArgb(50, 150, 250), 
                SpecialButtonFore = Color.White, 
                BorderColor = Color.FromArgb(100, 150, 200),
                TabBackground = Color.FromArgb(200, 220, 255),
                TabForeground = Color.FromArgb(0, 50, 100),
                MenuDropdownBack = Color.White,
                GroupBoxFore = Color.FromArgb(0, 50, 100),
                ComboBoxDropdownBack = Color.White
            }},
            { "Green", new ThemeColors { 
                Background = Color.FromArgb(230, 255, 230), 
                Foreground = Color.FromArgb(0, 80, 0), 
                DisplayBackground = Color.White, 
                DisplayForeground = Color.FromArgb(0, 80, 0), 
                NumberButtonBack = Color.White, 
                NumberButtonFore = Color.FromArgb(0, 80, 0), 
                OperatorButtonBack = Color.FromArgb(100, 200, 100), 
                OperatorButtonFore = Color.FromArgb(0, 80, 0), 
                ActionButtonBack = Color.FromArgb(0, 150, 0), 
                ActionButtonFore = Color.White, 
                SpecialButtonBack = Color.FromArgb(50, 200, 50), 
                SpecialButtonFore = Color.White, 
                BorderColor = Color.FromArgb(100, 200, 100),
                TabBackground = Color.FromArgb(200, 255, 200),
                TabForeground = Color.FromArgb(0, 80, 0),
                MenuDropdownBack = Color.White,
                GroupBoxFore = Color.FromArgb(0, 80, 0),
                ComboBoxDropdownBack = Color.White
            }},
            { "Purple", new ThemeColors { 
                Background = Color.FromArgb(240, 230, 255), 
                Foreground = Color.FromArgb(80, 0, 80), 
                DisplayBackground = Color.White, 
                DisplayForeground = Color.FromArgb(80, 0, 80), 
                NumberButtonBack = Color.White, 
                NumberButtonFore = Color.FromArgb(80, 0, 80), 
                OperatorButtonBack = Color.FromArgb(180, 140, 200), 
                OperatorButtonFore = Color.White, 
                ActionButtonBack = Color.FromArgb(128, 0, 128), 
                ActionButtonFore = Color.White, 
                SpecialButtonBack = Color.FromArgb(150, 50, 150), 
                SpecialButtonFore = Color.White, 
                BorderColor = Color.FromArgb(150, 100, 150),
                TabBackground = Color.FromArgb(220, 200, 255),
                TabForeground = Color.FromArgb(80, 0, 80),
                MenuDropdownBack = Color.White,
                GroupBoxFore = Color.FromArgb(80, 0, 80),
                ComboBoxDropdownBack = Color.White
            }}
        };

        // === 🎲 СЛУЧАЙНЫЕ ФИЧИ ===
        private Random rng = new Random();
        private Label diceResultLabel;
        private string[] fortunes;
        private string[] fortunesRu;
        private Label fortuneLabel;
        private Panel colorPreviewPanel;
        private Label colorCodeLabel;
        private int secretNumber;
        private int guessAttempts;
        private TextBox guessInputBox;
        private Label guessResultLabel;
        private int[] pianoFrequencies = { 262, 294, 330, 349, 392, 440, 494, 523 };
        private string[] pianoNotes = { "Do", "Re", "Mi", "Fa", "Sol", "La", "Si", "Do↑" };

        // Элементы для динамического обновления
        private GroupBox diceBox, fortuneBox, colorBox, guessBox, pianoBox;
        private Button rollBtn, fortuneBtn, colorBtn, guessBtn, newGameBtn;
        private ToolStripMenuItem fileMenu, themeMenu, funMenu, languageMenu;
        private List<Control> allControls = new List<Control>();

        public Form1()
        {
            InitializeComponents();
            ApplyTheme(currentTheme);
            ApplyLanguage(currentLanguage);
            StartNewGuessGame();
        }

        private void InitializeComponents()
        {
            this.Size = new Size(480, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // === МЕНЮ ===
            menuStrip = new MenuStrip();
            menuStrip.Renderer = new CustomToolStripRenderer();
            
            fileMenu = new ToolStripMenuItem("File");
            var exitItem = new ToolStripMenuItem("Exit");
            exitItem.Click += (s, e) => this.Close();
            fileMenu.DropDownItems.Add(exitItem);
            
            themeMenu = new ToolStripMenuItem("Theme");
            foreach (var themeName in themes.Keys)
            {
                var themeItem = new ToolStripMenuItem(themeName);
                themeItem.Click += (s, e) => { currentTheme = ((ToolStripMenuItem)s).Text; ApplyTheme(currentTheme); };
                themeMenu.DropDownItems.Add(themeItem);
            }
            
            funMenu = new ToolStripMenuItem("🎲 Entertainment");
            funMenu.DropDownItems.Add("🎲 Roll Dice", null, (s,e) => RollDice());
            funMenu.DropDownItems.Add("🔮 Fortune Cookie", null, (s,e) => ShowFortune());
            funMenu.DropDownItems.Add("🎨 Random Color", null, (s,e) => GenerateRandomColor());
            funMenu.DropDownItems.Add("🎮 New Game", null, (s,e) => StartNewGuessGame());
            funMenu.DropDownItems.Add("🎵 Play Melody", null, (s,e) => PlayMelody());
            
            languageMenu = new ToolStripMenuItem("🌐 Language");
            foreach (var langName in languages.Keys)
            {
                var langItem = new ToolStripMenuItem(langName);
                langItem.Click += (s, e) => { 
                    currentLanguage = ((ToolStripMenuItem)s).Text; 
                    ApplyLanguage(currentLanguage);
                    languageComboBox.SelectedItem = currentLanguage;
                };
                languageMenu.DropDownItems.Add(langItem);
            }
            
            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(themeMenu);
            menuStrip.Items.Add(funMenu);
            menuStrip.Items.Add(languageMenu);
            this.Controls.Add(menuStrip);

            // === TAB CONTROL ===
            mainTabs = new TabControl();
            mainTabs.Location = new Point(10, 80);
            mainTabs.Size = new Size(440, 480);
            mainTabs.DrawMode = TabDrawMode.OwnerDrawFixed; // ВАЖНО для кастомной отрисовки
            mainTabs.DrawItem += MainTabs_DrawItem; // ВАЖНО для кастомной отрисовки
            this.Controls.Add(mainTabs);

            // === ВКЛАДКИ ===
            TabPage calcTab = new TabPage("🔢 Calculator");
            calcTab.Name = "TabCalculator";
            SetupCalculatorTab(calcTab);
            mainTabs.TabPages.Add(calcTab);

            TabPage funTab = new TabPage("🎲 Entertainment");
            funTab.Name = "TabFun";
            SetupFunTab(funTab);
            mainTabs.TabPages.Add(funTab);

            TabPage aboutTab = new TabPage("ℹ️ About");
            aboutTab.Name = "TabAbout";
            SetupAboutTab(aboutTab);
            mainTabs.TabPages.Add(aboutTab);

            // === ComboBox для тем ===
            themeComboBox = new ComboBox();
            themeComboBox.Location = new Point(10, 50);
            themeComboBox.Size = new Size(120, 25);
            themeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            themeComboBox.Items.AddRange(new object[] { "Light", "Dark", "Blue", "Green", "Purple" });
            themeComboBox.SelectedItem = currentTheme;
            themeComboBox.SelectedIndexChanged += (s, e) => { currentTheme = themeComboBox.SelectedItem.ToString(); ApplyTheme(currentTheme); };
            this.Controls.Add(themeComboBox);

            // === ComboBox для языка ===
            languageComboBox = new ComboBox();
            languageComboBox.Location = new Point(140, 50);
            languageComboBox.Size = new Size(120, 25);
            languageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            languageComboBox.Items.AddRange(new object[] { "English", "Russian" });
            languageComboBox.SelectedItem = currentLanguage;
            languageComboBox.SelectedIndexChanged += (s, e) => { 
                currentLanguage = languageComboBox.SelectedItem.ToString(); 
                ApplyLanguage(currentLanguage);
            };
            this.Controls.Add(languageComboBox);

            // Инициализация предсказаний
            fortunes = new string[] {
                "Today is your day! 🌟", "Expect an unexpected turn 🔄", "Coffee will be extra tasty ☕",
                "Someone is thinking about you 💭", "Luck is on your side 🍀", "Don't be afraid to try new things 🚀",
                "The answer is closer than you think 🔍", "Laughter extends life 😄", "Your intuition won't fail you ✨",
                "Good news are on the way 📬"
            };
            fortunesRu = new string[] {
                "Сегодня ваш день! 🌟", "Ожидайте неожиданный поворот 🔄", "Кофе будет особенно вкусным ☕",
                "Кто-то думает о вас 💭", "Удача на вашей стороне 🍀", "Не бойтесь пробовать новое 🚀",
                "Ответ ближе, чем кажется 🔍", "Смех продлевает жизнь 😄", "Ваша интуиция вас не подведёт ✨",
                "Хорошие новости уже в пути 📬"
            };

            this.KeyPreview = true;
            this.KeyPress += Form1_KeyPress;
        }

        // === 🎨 КАСТОМНАЯ ОТРИСОВКА ВКЛАДОК (ИСПРАВЛЕНИЕ ТЁМНОЙ ТЕМЫ) ===
        private void MainTabs_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            TabPage tabPage = tabControl.TabPages[e.Index];
            
            ThemeColors c = themes[currentTheme];
            
            // Фон вкладки
            using (SolidBrush brush = new SolidBrush(c.TabBackground))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
            
            // Текст вкладки
            using (SolidBrush brush = new SolidBrush(c.TabForeground))
            {
                e.Graphics.DrawString(tabPage.Text, e.Font, brush, e.Bounds, new StringFormat { 
                    Alignment = StringAlignment.Center, 
                    LineAlignment = StringAlignment.Center 
                });
            }
            
            // Граница для активной вкладки
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                using (Pen pen = new Pen(c.BorderColor, 2))
                {
                    e.Graphics.DrawRectangle(pen, e.Bounds);
                }
            }
        }

        // === ПРИМЕНЕНИЕ ЯЗЫКА ===
        private void ApplyLanguage(string lang)
        {
            if (!languages.ContainsKey(lang)) return;
            var t = languages[lang];

            this.Text = t["Title"];
            mainTabs.TabPages[0].Text = t["TabCalculator"];
            mainTabs.TabPages[1].Text = t["TabFun"];
            mainTabs.TabPages[2].Text = t["TabAbout"];
            
            fileMenu.Text = t["MenuFile"];
            fileMenu.DropDownItems[0].Text = t["MenuExit"];
            themeMenu.Text = t["MenuTheme"];
            funMenu.Text = t["MenuFun"];
            funMenu.DropDownItems[0].Text = t["MenuRollDice"];
            funMenu.DropDownItems[1].Text = t["MenuFortune"];
            funMenu.DropDownItems[2].Text = t["MenuColor"];
            funMenu.DropDownItems[3].Text = t["MenuNewGame"];
            funMenu.DropDownItems[4].Text = t["MenuMelody"];
            languageMenu.Text = t["MenuLanguage"];
            
            if (buttons != null)
            {
                foreach (Button btn in buttons)
                {
                    if (btn.Tag != null)
                    {
                        string tag = btn.Tag.ToString();
                        if (tag == "Var") btn.Text = t["BtnVar"];
                        else if (tag == "Mem") btn.Text = t["BtnMem"];
                    }
                }
            }
            
            if (statusLabel != null)
                statusLabel.Text = variables.Count == 0 ? t["StatusVariables"] : 
                    t["StatusVariables"].Replace("none", string.Join(" ", variables.Keys));
            
            if (diceBox != null) diceBox.Text = t["GroupDice"];
            if (fortuneBox != null) fortuneBox.Text = t["GroupFortune"];
            if (colorBox != null) colorBox.Text = t["GroupColor"];
            if (guessBox != null) guessBox.Text = t["GroupGuess"];
            if (pianoBox != null) pianoBox.Text = t["GroupPiano"];
            
            if (rollBtn != null) rollBtn.Text = t["BtnRoll"];
            if (fortuneBtn != null) fortuneBtn.Text = t["BtnFortune"];
            if (colorBtn != null) colorBtn.Text = t["BtnColor"];
            if (guessBtn != null) guessBtn.Text = t["BtnCheck"];
            if (newGameBtn != null) newGameBtn.Text = t["BtnNewGame"];
            
            fortunes = lang == "English" ? new string[] {
                "Today is your day! 🌟", "Expect an unexpected turn 🔄", "Coffee will be extra tasty ☕",
                "Someone is thinking about you 💭", "Luck is on your side 🍀", "Don't be afraid to try new things 🚀",
                "The answer is closer than you think 🔍", "Laughter extends life 😄", "Your intuition won't fail you ✨",
                "Good news are on the way 📬"
            } : new string[] {
                "Сегодня ваш день! 🌟", "Ожидайте неожиданный поворот 🔄", "Кофе будет особенно вкусным ☕",
                "Кто-то думает о вас 💭", "Удача на вашей стороне 🍀", "Не бойтесь пробовать новое 🚀",
                "Ответ ближе, чем кажется 🔍", "Смех продлевает жизнь 😄", "Ваша интуиция вас не подведёт ✨",
                "Хорошие новости уже в пути 📬"
            };
            
            foreach (TabPage tab in mainTabs.TabPages)
            {
                if (tab.Name == "TabAbout")
                {
                    foreach (Control ctrl in tab.Controls)
                    {
                        if (ctrl is Label lbl)
                            lbl.Text = t["AboutText"];
                    }
                }
            }
            
            if (guessResultLabel != null && guessAttempts == 0)
                guessResultLabel.Text = t["LblGuessStart"];
            
            mainTabs.Invalidate(); // Перерисовать вкладки
        }

        private void SetupCalculatorTab(TabPage tab)
        {
            displayBox = new TextBox();
            displayBox.Location = new Point(10, 10);
            displayBox.Size = new Size(400, 40);
            displayBox.Font = new Font("Arial", 20, FontStyle.Bold);
            displayBox.TextAlign = HorizontalAlignment.Right;
            displayBox.ReadOnly = false;
            displayBox.KeyPress += DisplayBox_KeyPress;
            tab.Controls.Add(displayBox);

            string[] buttonTexts = { "7","8","9","/", "4","5","6","*", "1","2","3","-", "0","C","=","+", ".","←","Var","Mem" };
            string[] buttonTags = { "7","8","9","/", "4","5","6","*", "1","2","3","-", "0","C","=","+", ".","←","Var","Mem" };
            buttons = new Button[buttonTexts.Length];
            int startX = 10, startY = 60, btnWidth = 90, btnHeight = 55, gap = 5;

            for (int i = 0; i < buttonTexts.Length; i++)
            {
                buttons[i] = new Button();
                buttons[i].Text = buttonTexts[i];
                buttons[i].Tag = buttonTags[i];
                int col = i % 4, row = i / 4;
                buttons[i].Location = new Point(startX + col*(btnWidth+gap), startY + row*(btnHeight+gap));
                buttons[i].Size = new Size(btnWidth, btnHeight);
                buttons[i].Font = new Font("Arial", 14, FontStyle.Bold);
                buttons[i].Click += Button_Click;
                buttons[i].FlatStyle = FlatStyle.Flat;
                buttons[i].FlatAppearance.BorderSize = 1;
                tab.Controls.Add(buttons[i]);
            }

            statusLabel = new Label();
            statusLabel.Location = new Point(10, 400);
            statusLabel.Size = new Size(410, 25);
            statusLabel.Text = languages[currentLanguage]["StatusVariables"];
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            tab.Controls.Add(statusLabel);
        }

        private void SetupFunTab(TabPage tab)
        {
            diceBox = new GroupBox();
            diceBox.Text = languages[currentLanguage]["GroupDice"];
            diceBox.Location = new Point(10, 10);
            diceBox.Size = new Size(400, 80);
            
            rollBtn = new Button();
            rollBtn.Text = languages[currentLanguage]["BtnRoll"];
            rollBtn.Location = new Point(10, 25);
            rollBtn.Size = new Size(100, 40);
            rollBtn.Click += (s,e) => RollDice();
            
            diceResultLabel = new Label();
            diceResultLabel.Location = new Point(120, 25);
            diceResultLabel.Size = new Size(270, 40);
            diceResultLabel.Font = new Font("Arial", 18, FontStyle.Bold);
            diceResultLabel.TextAlign = ContentAlignment.MiddleCenter;
            diceResultLabel.BorderStyle = BorderStyle.FixedSingle;
            
            diceBox.Controls.Add(rollBtn);
            diceBox.Controls.Add(diceResultLabel);
            tab.Controls.Add(diceBox);

            fortuneBox = new GroupBox();
            fortuneBox.Text = languages[currentLanguage]["GroupFortune"];
            fortuneBox.Location = new Point(10, 100);
            fortuneBox.Size = new Size(400, 80);
            
            fortuneBtn = new Button();
            fortuneBtn.Text = languages[currentLanguage]["BtnFortune"];
            fortuneBtn.Location = new Point(10, 25);
            fortuneBtn.Size = new Size(150, 40);
            fortuneBtn.Click += (s,e) => ShowFortune();
            
            fortuneLabel = new Label();
            fortuneLabel.Location = new Point(170, 25);
            fortuneLabel.Size = new Size(220, 40);
            fortuneLabel.Font = new Font("Arial", 10);
            fortuneLabel.TextAlign = ContentAlignment.MiddleCenter;
            fortuneLabel.BorderStyle = BorderStyle.FixedSingle;
            
            fortuneBox.Controls.Add(fortuneBtn);
            fortuneBox.Controls.Add(fortuneLabel);
            tab.Controls.Add(fortuneBox);

            colorBox = new GroupBox();
            colorBox.Text = languages[currentLanguage]["GroupColor"];
            colorBox.Location = new Point(10, 190);
            colorBox.Size = new Size(400, 80);
            
            colorBtn = new Button();
            colorBtn.Text = languages[currentLanguage]["BtnColor"];
            colorBtn.Location = new Point(10, 25);
            colorBtn.Size = new Size(100, 40);
            colorBtn.Click += (s,e) => GenerateRandomColor();
            
            colorPreviewPanel = new Panel();
            colorPreviewPanel.Location = new Point(120, 20);
            colorPreviewPanel.Size = new Size(60, 50);
            colorPreviewPanel.BorderStyle = BorderStyle.FixedSingle;
            
            colorCodeLabel = new Label();
            colorCodeLabel.Location = new Point(190, 30);
            colorCodeLabel.Size = new Size(200, 30);
            colorCodeLabel.Font = new Font("Consolas", 10);
            colorCodeLabel.TextAlign = ContentAlignment.MiddleLeft;
            
            colorBox.Controls.Add(colorBtn);
            colorBox.Controls.Add(colorPreviewPanel);
            colorBox.Controls.Add(colorCodeLabel);
            tab.Controls.Add(colorBox);

            guessBox = new GroupBox();
            guessBox.Text = languages[currentLanguage]["GroupGuess"];
            guessBox.Location = new Point(10, 280);
            guessBox.Size = new Size(400, 90);
            
            guessInputBox = new TextBox();
            guessInputBox.Location = new Point(10, 25);
            guessInputBox.Size = new Size(60, 25);
            guessInputBox.Font = new Font("Arial", 12);
            guessInputBox.TextAlign = HorizontalAlignment.Center;
            
            guessBtn = new Button();
            guessBtn.Text = languages[currentLanguage]["BtnCheck"];
            guessBtn.Location = new Point(80, 25);
            guessBtn.Size = new Size(90, 40);
            guessBtn.Click += (s,e) => CheckGuess();
            
            newGameBtn = new Button();
            newGameBtn.Text = languages[currentLanguage]["BtnNewGame"];
            newGameBtn.Location = new Point(180, 25);
            newGameBtn.Size = new Size(110, 40);
            newGameBtn.Click += (s,e) => StartNewGuessGame();
            
            guessResultLabel = new Label();
            guessResultLabel.Location = new Point(10, 60);
            guessResultLabel.Size = new Size(380, 25);
            guessResultLabel.Font = new Font("Arial", 9);
            guessResultLabel.TextAlign = ContentAlignment.MiddleLeft;
            guessResultLabel.Text = languages[currentLanguage]["LblGuessStart"];
            
            guessBox.Controls.Add(guessInputBox);
            guessBox.Controls.Add(guessBtn);
            guessBox.Controls.Add(newGameBtn);
            guessBox.Controls.Add(guessResultLabel);
            tab.Controls.Add(guessBox);

            pianoBox = new GroupBox();
            pianoBox.Text = languages[currentLanguage]["GroupPiano"];
            pianoBox.Location = new Point(10, 380);
            pianoBox.Size = new Size(400, 70);
            
            for (int i = 0; i < 8; i++)
            {
                Button pianoKey = new Button();
                pianoKey.Text = pianoNotes[i];
                pianoKey.Location = new Point(10 + i*47, 25);
                pianoKey.Size = new Size(44, 35);
                pianoKey.Font = new Font("Arial", 8);
                int index = i;
                pianoKey.Click += (s,e) => PlayNote(pianoFrequencies[index]);
                pianoKey.BackColor = Color.White;
                pianoBox.Controls.Add(pianoKey);
            }
            tab.Controls.Add(pianoBox);
        }

        private void SetupAboutTab(TabPage tab)
        {
            Label aboutLabel = new Label();
            aboutLabel.Location = new Point(20, 20);
            aboutLabel.Size = new Size(390, 420);
            aboutLabel.Font = new Font("Arial", 10);
            aboutLabel.Text = languages[currentLanguage]["AboutText"];
            aboutLabel.TextAlign = ContentAlignment.TopLeft;
            tab.Controls.Add(aboutLabel);
        }

        // === 🔧 ПРИМЕНЕНИЕ ТЕМЫ (ИСПРАВЛЕННАЯ ВЕРСИЯ) ===
        private void ApplyTheme(string themeName)
        {
            if (!themes.ContainsKey(themeName)) return;
            ThemeColors c = themes[themeName];
            
            // Форма
            this.BackColor = c.Background;
            this.ForeColor = c.Foreground;
            
            // Display
            if(displayBox != null) { 
                displayBox.BackColor = c.DisplayBackground; 
                displayBox.ForeColor = c.DisplayForeground; 
            }
            
            // Кнопки калькулятора
            foreach(Button btn in buttons)
            {
                string t = btn.Text;
                if(t=="="||t=="C"||t=="←") { 
                    btn.BackColor = c.ActionButtonBack; 
                    btn.ForeColor = c.ActionButtonFore; 
                }
                else if(t=="+"||t=="-"||t=="*"||t=="/") { 
                    btn.BackColor = c.OperatorButtonBack; 
                    btn.ForeColor = c.OperatorButtonFore; 
                }
                else if(t==languages["English"]["BtnVar"]||t==languages["English"]["BtnMem"]||
                        t==languages["Russian"]["BtnVar"]||t==languages["Russian"]["BtnMem"]) 
                { 
                    btn.BackColor = c.SpecialButtonBack; 
                    btn.ForeColor = c.SpecialButtonFore; 
                }
                else { 
                    btn.BackColor = c.NumberButtonBack; 
                    btn.ForeColor = c.NumberButtonFore; 
                }
                btn.FlatAppearance.BorderColor = c.BorderColor;
            }
            
            // ComboBox
            if(themeComboBox != null) {
                themeComboBox.BackColor = c.DisplayBackground;
                themeComboBox.ForeColor = c.DisplayForeground;
            }
            if(languageComboBox != null) {
                languageComboBox.BackColor = c.DisplayBackground;
                languageComboBox.ForeColor = c.DisplayForeground;
            }
            
            // Status Label
            if(statusLabel != null)
                statusLabel.ForeColor = c.Foreground;
            
            // TabControl
            if(mainTabs != null) {
                mainTabs.BackColor = c.TabBackground;
                mainTabs.ForeColor = c.TabForeground;
                foreach(TabPage tab in mainTabs.TabPages) {
                    tab.BackColor = c.Background;
                    tab.ForeColor = c.Foreground;
                    // Обновляем все контролы на вкладке
                    foreach(Control ctrl in tab.Controls) {
                        UpdateControlColors(ctrl, c);
                    }
                }
                mainTabs.Invalidate(); // Перерисовать вкладки
            }
            
            // MenuStrip
            if(menuStrip != null) {
                menuStrip.BackColor = c.Background;
                menuStrip.ForeColor = c.Foreground;
                foreach(ToolStripMenuItem item in menuStrip.Items) {
                    item.BackColor = c.Background;
                    item.ForeColor = c.Foreground;
                    item.DropDown.BackColor = c.MenuDropdownBack;
                    foreach(ToolStripMenuItem subItem in item.DropDownItems) {
                        subItem.BackColor = c.MenuDropdownBack;
                        subItem.ForeColor = c.Foreground;
                    }
                }
            }
            
            // Обновляем ComboBox
            themeComboBox.SelectedItem = themeName;
        }

        // === 🔧 ОБНОВЛЕНИЕ ЦВЕТОВ КОНТРОЛОВ (ИСПРАВЛЕНИЕ ТЁМНОЙ ТЕМЫ) ===
        private void UpdateControlColors(Control ctrl, ThemeColors c)
        {
            if (ctrl is GroupBox gb)
            {
                gb.ForeColor = c.GroupBoxFore;
                foreach (Control child in gb.Controls)
                {
                    UpdateControlColors(child, c);
                }
            }
            else if (ctrl is Label lbl)
            {
                lbl.ForeColor = c.Foreground;
                if (lbl.BorderStyle == BorderStyle.FixedSingle)
                    lbl.BackColor = c.DisplayBackground;
            }
            else if (ctrl is TextBox tb)
            {
                tb.BackColor = c.DisplayBackground;
                tb.ForeColor = c.DisplayForeground;
            }
            else if (ctrl is Button btn)
            {
                // Кнопки уже настроены в ApplyTheme
            }
            else if (ctrl is Panel pnl)
            {
                // Панели сохраняют свой цвет (для превью цвета)
            }
            
            // Рекурсивно обновляем вложенные контролы
            foreach (Control child in ctrl.Controls)
            {
                UpdateControlColors(child, c);
            }
        }

        // === 🎲 ФУНКЦИИ РАЗВЛЕЧЕНИЙ ===
        private void RollDice()
        {
            int result = rng.Next(1, 7);
            string diceEmoji = result switch { 1 => "⚀", 2 => "⚁", 3 => "⚂", 4 => "⚃", 5 => "⚄", 6 => "⚅", _ => "🎲" };
            diceResultLabel.Text = languages[currentLanguage]["LblDiceResult"] + result + " " + diceEmoji;
            for(int i=0; i<5; i++) { 
                diceResultLabel.Text = "🎲 ..."; 
                this.Refresh(); 
                System.Threading.Thread.Sleep(50); 
            }
            diceResultLabel.Text = languages[currentLanguage]["LblDiceResult"] + result + " " + diceEmoji;
        }

        private void ShowFortune()
        {
            fortuneLabel.Text = currentLanguage == "English" ? "🥠 Breaking..." : "🥠 Ломаем...";
            this.Refresh();
            System.Threading.Thread.Sleep(300);
            fortuneLabel.Text = fortunes[rng.Next(fortunes.Length)];
        }

        private void GenerateRandomColor()
        {
            Color randomColor = Color.FromArgb(rng.Next(256), rng.Next(256), rng.Next(256));
            colorPreviewPanel.BackColor = randomColor;
            string hex = $"#{randomColor.R:X2}{randomColor.G:X2}{randomColor.B:X2}";
            string rgb = $"RGB({randomColor.R},{randomColor.G},{randomColor.B})";
            colorCodeLabel.Text = $"{hex}\n{rgb}";
        }

        private void StartNewGuessGame()
        {
            secretNumber = rng.Next(1, 101);
            guessAttempts = 0;
            guessResultLabel.Text = languages[currentLanguage]["LblGuessStart"];
            guessInputBox.Text = "";
            guessInputBox.Focus();
        }

        private void CheckGuess()
        {
            if (int.TryParse(guessInputBox.Text, out int guess))
            {
                guessAttempts++;
                if (guess == secretNumber)
                {
                    guessResultLabel.Text = string.Format(languages[currentLanguage]["MsgWin"], secretNumber, guessAttempts);
                    guessResultLabel.ForeColor = Color.Green;
                }
                else if (guess < secretNumber)
                {
                    guessResultLabel.Text = string.Format(languages[currentLanguage]["MsgTooLow"], guessAttempts);
                    guessResultLabel.ForeColor = Color.Blue;
                }
                else
                {
                    guessResultLabel.Text = string.Format(languages[currentLanguage]["MsgTooHigh"], guessAttempts);
                    guessResultLabel.ForeColor = Color.Red;
                }
            }
            else
            {
                guessResultLabel.Text = languages[currentLanguage]["MsgEnterNumber"];
                guessResultLabel.ForeColor = Color.Orange;
            }
        }

        private void PlayNote(int frequency) => Console.Beep(frequency, 200);

        private void PlayMelody()
        {
            int[] melody = { 262, 262, 294, 262, 349, 330 };
            foreach (int freq in melody) { 
                Console.Beep(freq, 300); 
                System.Threading.Thread.Sleep(50); 
            }
            MessageBox.Show(languages[currentLanguage]["MsgMelody"], languages[currentLanguage]["MsgMelodyTitle"], 
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // === КАЛЬКУЛЯТОР: ОБРАБОТЧИКИ ===
        private void Form1_KeyPress(object sender, KeyPressEventArgs e) { }
        private void DisplayBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar) || 
                e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || 
                e.KeyChar == '/' || e.KeyChar == '=' || e.KeyChar == '.' || 
                e.KeyChar == ',' || e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else e.Handled = true;
        }
        
        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string text = btn.Text;

            if (text == "C") { displayBox.Text = "0"; firstNumber = 0; operation = ""; isOperatorPressed = false; }
            else if (text == "←") { if (displayBox.Text.Length > 1) displayBox.Text = displayBox.Text.Substring(0, displayBox.Text.Length - 1); else displayBox.Text = "0"; }
            else if (text == languages["English"]["BtnVar"] || text == languages["Russian"]["BtnVar"]) SaveVariable();
            else if (text == languages["English"]["BtnMem"] || text == languages["Russian"]["BtnMem"]) ShowVariables();
            else if (text == "=") { CalculateResult(); isOperatorPressed = true; }
            else if (text == "+" || text == "-" || text == "*" || text == "/") { if (displayBox.Text != "") { firstNumber = ParseValue(displayBox.Text); operation = text; isOperatorPressed = true; } }
            else if (text == ".") { if (!displayBox.Text.Contains(",") && !displayBox.Text.Contains(".")) { displayBox.Text += ","; isOperatorPressed = false; } }
            else { if (isOperatorPressed || displayBox.Text == "0") { displayBox.Text = text; isOperatorPressed = false; } else { displayBox.Text += text; } }
        }

        private void SaveVariable()
        {
            string input = displayBox.Text.Trim();
            var t = languages[currentLanguage];
            if (input.Contains("=")) {
                string[] parts = input.Split('=');
                if (parts.Length == 2 && parts[0].Length == 1 && char.IsLetter(parts[0][0])) {
                    string varName = parts[0].ToLower();
                    if (double.TryParse(parts[1], out double value)) {
                        variables[varName] = value;
                        MessageBox.Show(string.Format(t["MsgVarSaved"], varName, value), t["MsgSuccess"], MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateStatusLabel(); displayBox.Text = "0";
                    } else MessageBox.Show(t["MsgVarError"], t["MsgError"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else MessageBox.Show(t["MsgVarFormat"], t["MsgError"], MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else MessageBox.Show(t["MsgVarInfo"], t["MsgInfo"], MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowVariables()
        {
            var t = languages[currentLanguage];
            if (variables.Count == 0) MessageBox.Show(t["MsgNoVars"], t["MsgInfo"], MessageBoxButtons.OK, MessageBoxIcon.Information);
            else { string m = t["MsgVarsTitle"] + ":\n\n"; foreach(var v in variables) m += $"{v.Key} = {v.Value}\n"; MessageBox.Show(m, t["MsgVarsTitle"], MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private double ParseValue(string text)
        {
            var t = languages[currentLanguage];
            if (text.Length == 1 && char.IsLetter(text[0])) {
                string varName = text.ToLower();
                if (variables.ContainsKey(varName)) return variables[varName];
                else { MessageBox.Show(string.Format(t["MsgVarNotFound"], text), t["MsgError"], MessageBoxButtons.OK, MessageBoxIcon.Warning); return 0; }
            }
            if (double.TryParse(text.Replace('.', ','), out double result)) return result;
            return 0;
        }

        private void CalculateResult()
        {
            var t = languages[currentLanguage];
            if (operation == "") return;
            try {
                secondNumber = ParseValue(displayBox.Text); double result = 0;
                switch (operation) {
                    case "+": result = firstNumber + secondNumber; break;
                    case "-": result = firstNumber - secondNumber; break;
                    case "*": result = firstNumber * secondNumber; break;
                    case "/": if (secondNumber != 0) result = firstNumber / secondNumber; else { MessageBox.Show(t["MsgDivZero"], t["MsgError"], MessageBoxButtons.OK, MessageBoxIcon.Error); displayBox.Text = "0"; return; } break;
                }
                displayBox.Text = result.ToString(); operation = ""; firstNumber = result;
            } catch (Exception ex) { MessageBox.Show(string.Format(t["MsgCalcError"], ex.Message), t["MsgError"], MessageBoxButtons.OK, MessageBoxIcon.Error); displayBox.Text = "0"; }
        }

        private void UpdateStatusLabel()
        {
            var t = languages[currentLanguage];
            statusLabel.Text = variables.Count == 0 ? t["StatusVariables"] : t["StatusVariables"].Replace("none", string.Join(" ", variables.Keys));
        }
    }

    // === 🎨 КЛАСС ЦВЕТОВ ТЕМЫ (ДОБАВЛЕНЫ НОВЫЕ СВОЙСТВА) ===
    public class ThemeColors {
        public Color Background, Foreground, DisplayBackground, DisplayForeground;
        public Color NumberButtonBack, NumberButtonFore, OperatorButtonBack, OperatorButtonFore;
        public Color ActionButtonBack, ActionButtonFore, SpecialButtonBack, SpecialButtonFore, BorderColor;
        public Color TabBackground, TabForeground; // Для вкладок
        public Color MenuDropdownBack; // Для меню
        public Color GroupBoxFore; // Для заголовков GroupBox
        public Color ComboBoxDropdownBack; // Для ComboBox
    }

    // === 🎨 КАСТОМНЫЙ РЕНДЕРЕР ДЛЯ МЕНЮ (ИСПРАВЛЕНИЕ ТЁМНОЙ ТЕМЫ) ===
    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item is ToolStripMenuItem item && item.OwnerItem != null)
            {
                // Выпадающее меню
                if (item.Selected)
                {
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(80, 80, 80)))
                    {
                        e.Graphics.FillRectangle(brush, item.Bounds);
                    }
                }
            }
            else
            {
                // Главное меню
                base.OnRenderMenuItemBackground(e);
            }
        }
    }
}