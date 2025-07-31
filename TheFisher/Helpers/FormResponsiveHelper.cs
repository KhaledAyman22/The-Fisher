using System.Drawing;
using System.Windows.Forms;

namespace TheFisher
{
    /// <summary>
    /// Helper class to make forms responsive to window resizing
    /// </summary>
    public static class FormResponsiveHelper
    {
        /// <summary>
        /// Sets up a form to be responsive by configuring anchoring and docking
        /// </summary>
        /// <param name="form">The form to make responsive</param>
        public static void SetupResponsiveForm(Form form)
        {
            // Set a reasonable minimum size to prevent layout issues
            form.MinimumSize = new Size(800, 600);

            // Configure all child controls to be responsive
            ConfigureControlsRecursively(form.Controls);
            
            // Add resize event handler to reposition controls when form size changes
            form.Resize += (sender, e) => {
                RepositionControls(form.Controls);
            };
        }

        /// <summary>
        /// Recursively configures controls to be responsive
        /// </summary>
        /// <param name="controls">Collection of controls to configure</param>
        private static void ConfigureControlsRecursively(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Panel || control is GroupBox || control is TableLayoutPanel || control is FlowLayoutPanel)
                {
                    // Container controls should expand to fill available space
                    control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    
                    // If it's a data display panel, consider docking it
                    if (control.Name.Contains("Panel") || control.Name.Contains("Container"))
                    {
                        control.Dock = DockStyle.Fill;
                    }
                    
                    // Process child controls recursively
                    ConfigureControlsRecursively(control.Controls);
                }
                else if (control is DataGridView)
                {
                    // Data grids should expand in all directions
                    control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    
                    // Make columns resize proportionally
                    DataGridView grid = (DataGridView)control;
                    foreach (DataGridViewColumn col in grid.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                else if (control is Button)
                {
                    // Buttons typically anchor to bottom right for dialog forms
                    control.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                }
                else if (control is TextBox || control is ComboBox)
                {
                    // Input controls typically stretch horizontally but maintain vertical position
                    control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                }
                else if (control is Label)
                {
                    // Labels typically maintain their position relative to what they're labeling
                    if (control.Name.Contains("Title") || control.Name.Contains("Header"))
                    {
                        control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    }
                    else
                    {
                        control.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    }
                }
                else if (control is MenuStrip)
                {
                    // Menu strips should stretch across the top
                    control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                }
                else
                {
                    // Default anchoring for other controls
                    control.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                }
                
                // Process child controls if any
                if (control.Controls.Count > 0)
                {
                    ConfigureControlsRecursively(control.Controls);
                }
            }
        }
        
        /// <summary>
        /// Repositions controls when the form is resized
        /// </summary>
        /// <param name="controls">Collection of controls to reposition</param>
        private static void RepositionControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Reposition card-style panels in a grid layout if needed
                if (control is Panel panel && (panel.Name.Contains("Card") || panel.Name.Contains("Tile")))
                {
                    // Custom positioning logic for card layouts can be implemented here
                    // This would depend on the specific UI design
                }
                
                // Recursively reposition child controls
                if (control.Controls.Count > 0)
                {
                    RepositionControls(control.Controls);
                }
            }
        }
        
        /// <summary>
        /// Sets up a responsive card layout within a container
        /// </summary>
        /// <param name="container">The container panel</param>
        /// <param name="cards">The card panels to arrange</param>
        /// <param name="columns">Number of columns in the grid</param>
        /// <param name="margin">Margin between cards</param>
        public static void SetupResponsiveCardLayout(Panel container, Panel[] cards, int columns, int margin = 20)
        {
            // Calculate card dimensions based on container size and grid specifications
            int rows = (int)Math.Ceiling((double)cards.Length / columns);
            int cardWidth = (container.Width - ((columns + 1) * margin)) / columns;
            int cardHeight = (container.Height - ((rows + 1) * margin)) / rows;
            
            for (int i = 0; i < cards.Length; i++)
            {
                int row = i / columns;
                int col = i % columns;
                
                cards[i].Size = new Size(cardWidth, cardHeight);
                cards[i].Location = new Point(
                    margin + (col * (cardWidth + margin)),
                    margin + (row * (cardHeight + margin))
                );
                
                // Make cards responsive within the container
                cards[i].Anchor = AnchorStyles.None;
            }
            
            // Update card layout when container resizes
            container.Resize += (sender, e) => {
                cardWidth = (container.Width - ((columns + 1) * margin)) / columns;
                cardHeight = (container.Height - ((rows + 1) * margin)) / rows;
                
                for (int i = 0; i < cards.Length; i++)
                {
                    int row = i / columns;
                    int col = i % columns;
                    
                    cards[i].Size = new Size(cardWidth, cardHeight);
                    cards[i].Location = new Point(
                        margin + (col * (cardWidth + margin)),
                        margin + (row * (cardHeight + margin))
                    );
                }
            };
        }
    }
}
