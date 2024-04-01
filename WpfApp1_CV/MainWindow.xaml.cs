using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1_CV
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BuildCV();
        }

        private void BuildCV()
        {
            StackPanel cvPanel = new StackPanel
            {
                Margin = new Thickness(20),
                Background = Brushes.LightBlue
            };

            TextBlock nameTextBlock = new TextBlock
            {
                Text = "John Doe",
                FontSize = 20,
                Margin = new Thickness(0, 0, 0, 10)
            };
            cvPanel.Children.Add(nameTextBlock);
            AddThinLine(cvPanel);

            TextBlock contactTextBlock = new TextBlock
            {
                Text = "Contact: john.doe@example.com\nPhone: +1 123-456-7890\nAddress: 123 Main Street, City, Country",
                Margin = new Thickness(0, 0, 0, 10)
            };
            cvPanel.Children.Add(contactTextBlock);
            AddThinLine(cvPanel); 

            ToggleButton educationButton = new ToggleButton
            {
                Content = "Education",
                Margin = new Thickness(0, 0, 0, 10),
                Background = Brushes.Pink,
                BorderThickness = new Thickness(0) 
            };
            cvPanel.Children.Add(educationButton);
            TextBlock educationTextBlock = new TextBlock
            {
                Text = "Education:\nBachelor of Science in Computer Science\nUniversity of Example, Year Graduated",
                Margin = new Thickness(20, 0, 0, 10),
                Visibility = Visibility.Collapsed
            };
            cvPanel.Children.Add(educationTextBlock);
            educationButton.Checked += (sender, e) => educationTextBlock.Visibility = Visibility.Visible;
            educationButton.Unchecked += (sender, e) => educationTextBlock.Visibility = Visibility.Collapsed;

            ToggleButton experienceButton = new ToggleButton
            {
                Content = "Work Experience",
                Margin = new Thickness(0, 0, 0, 10),
                Background = Brushes.Pink,
                BorderThickness = new Thickness(0) 
            };
            cvPanel.Children.Add(experienceButton);
            TextBlock experienceTextBlock = new TextBlock
            {
                Text = "Work Experience:\nSoftware Developer\nCompany ABC, 2020 - Present",
                Margin = new Thickness(20, 0, 0, 10),
                Visibility = Visibility.Collapsed
            };
            cvPanel.Children.Add(experienceTextBlock);
            experienceButton.Checked += (sender, e) => experienceTextBlock.Visibility = Visibility.Visible;
            experienceButton.Unchecked += (sender, e) => experienceTextBlock.Visibility = Visibility.Collapsed;

            AddSkillsSection(cvPanel);

            Content = cvPanel;
        }

        private void AddSkillsSection(Panel cvPanel)
        {
            cvPanel.Children.Add(new TextBlock
            {
                Text = "Skills:",
                Margin = new Thickness(0, 0, 0, 10)
            });

            Grid skillsGrid = new Grid
            {
                Margin = new Thickness(0, 0, 0, 20)
            };

            string[] skills = { "C#", "WPF", ".NET Framework", "HTML", "CSS", "C++", "Python" };

            foreach (var skill in skills)
            {
                skillsGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                var skillButton = new Button
                {
                    Content = skill,
                    Margin = new Thickness(5),
                    Padding = new Thickness(10),
                    Background = Brushes.LightSkyBlue,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                skillButton.Click += SkillButton_Click;

                Grid.SetRow(skillButton, skillsGrid.RowDefinitions.Count - 1);
                skillsGrid.Children.Add(skillButton);
            }

            cvPanel.Children.Add(skillsGrid);
        }

        private void SkillButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                MessageBox.Show($"Skill: {clickedButton.Content} clicked!", "Skill Clicked");
            }
        }

        private void AddThinLine(Panel panel)
        {
            Border line = new Border
            {
                Background = Brushes.Black,
                Height = 0.5,
                Margin = new Thickness(0, 10, 0, 10)
            };
            panel.Children.Add(line);
        }
    }
}