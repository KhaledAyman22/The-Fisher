using System;
using System.Windows.Forms;
using TheFisher.Helpers;

namespace TheFisher
{
    /// <summary>
    /// Base form class that implements responsive behavior for all forms in the application
    /// </summary>
    public class BaseForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the BaseForm class
        /// </summary>
        public BaseForm()
        {
            // Set minimum size to prevent controls from becoming too small or overlapping
            this.MinimumSize = new Size(800, 600);
            
            // Subscribe to the Load event to set up responsive behavior
            this.Load += BaseForm_Load;
        }
        
        private void BaseForm_Load(object? sender, EventArgs e)
        {
            // Apply responsive behavior to this form
            FormResponsiveHelper.SetupResponsiveForm(this);
            
            // Call the derived class's initialization
            OnFormLoaded();
        }
        
        /// <summary>
        /// Called when the form is loaded. Override this method in derived classes
        /// to perform form-specific initialization.
        /// </summary>
        protected virtual void OnFormLoaded()
        {
            // Default implementation does nothing
        }
        
        /// <summary>
        /// Sets up a responsive card layout within a container panel
        /// </summary>
        /// <param name="container">The container panel</param>
        /// <param name="cards">Array of card panels to arrange</param>
        /// <param name="columns">Number of columns in the grid</param>
        /// <param name="margin">Margin between cards</param>
        protected void SetupCardLayout(Panel container, Panel[] cards, int columns, int margin = 20)
        {
            FormResponsiveHelper.SetupResponsiveCardLayout(container, cards, columns, margin);
        }
        
        /// <summary>
        /// Arranges controls in a horizontal flow layout
        /// </summary>
        /// <param name="container">The container panel</param>
        /// <param name="controls">Controls to arrange</param>
        /// <param name="margin">Margin between controls</param>
        protected void ArrangeControlsHorizontally(Panel container, Control[] controls, int margin = 10)
        {
            int x = margin;
            
            foreach (var control in controls)
            {
                control.Location = new Point(x, (container.Height - control.Height) / 2);
                x += control.Width + margin;
                
                // Anchor to maintain position on container resize
                control.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            }
        }
        
        /// <summary>
        /// Arranges controls in a vertical flow layout
        /// </summary>
        /// <param name="container">The container panel</param>
        /// <param name="controls">Controls to arrange</param>
        /// <param name="margin">Margin between controls</param>
        protected void ArrangeControlsVertically(Panel container, Control[] controls, int margin = 10)
        {
            int y = margin;
            
            foreach (var control in controls)
            {
                control.Location = new Point((container.Width - control.Width) / 2, y);
                y += control.Height + margin;
                
                // Anchor to maintain position on container resize
                control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
    }
}
