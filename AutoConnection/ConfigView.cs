using System.Windows.Forms;

namespace AutoConnection
{
    public partial class ConfigView : UserControl
    {
        #region Public Methods

        public ConfigView()
        {
            InitializeComponent();
            Initialize();
        }

        public void Add(WindowParameters? windowParameters = null)
        {
            var newPage = new TabPage();
            WindowParameters selectedObject = (windowParameters ?? new WindowParameters());

            var propertyGrid = new PropertyGrid()
            {
                Dock = DockStyle.Fill,
                SelectedObject = selectedObject
            };

            newPage.Controls.Add(propertyGrid);
            TabControl.TabPageCollection tabPages = tabControl.TabPages;
            int nextIndex = (tabControl.SelectedIndex + 1);

            if (nextIndex == tabPages.Count)
            {
                tabPages.Add(newPage);
            }
            else
            {
                tabPages.Insert(nextIndex, newPage);
            }

            int i = 1;

            foreach (TabPage tabPage in tabPages)
            {
                tabPage.Text = i.ToString();
                ++i;
            }
        }

        public void Initialize()
        {
            tabControl.TabPages.Clear();
            Add();
        }

        public WindowParameters[] GetParameters()
        {
            TabControl.TabPageCollection tabPages = tabControl.TabPages;
            var result = new WindowParameters[tabPages.Count];
            int i = 0;

            foreach (TabPage tabPage in tabPages)
            {
                result[i] = (WindowParameters)((tabPage.Controls[0] as PropertyGrid).SelectedObject);
            }

            return result;
        }

        public void Remove()
        {
            int selectedIndex = tabControl.SelectedIndex;

            if (selectedIndex < 0) return;

            tabControl.TabPages.RemoveAt(selectedIndex);
        }

        public void SetParameters(WindowParameters[] parameters)
        {
            tabControl.TabPages.Clear();
            bool added = false;

            foreach (WindowParameters parameters_ in parameters)
            {
                Add(parameters_);
                added |= true;
            }

            if (added)
            {
                tabControl.SelectedIndex = 0;
                return;
            }

            Add();
        }

        #endregion
    }
}
