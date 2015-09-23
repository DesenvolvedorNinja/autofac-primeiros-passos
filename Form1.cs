using Autofac;
using System;
using System.Windows.Forms;

namespace AutofacDemoWin
{
    public partial class FormAutofacDemoWin : Form
    {
        private IContainer _container;

        public FormAutofacDemoWin()
        {
            InitializeComponent();
        }

        private void buttonObterLinguagemDefault_Click(object sender, EventArgs e)
        {
            IDesenvolvedor desenvolvedor = new DesenvolvedorNinja();
            MessageBox.Show(desenvolvedor.GetLinguagemProgramacao());
        }

        private void FormAutofacDemoWin_Load(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DesenvolvedorNinja>().As<IDesenvolvedor>().InstancePerDependency();
            _container = builder.Build();
        }

        private void buttonObterLinguagemAutofac_Click(object sender, EventArgs e)
        {
            IDesenvolvedor desenvolvedor = _container.Resolve<IDesenvolvedor>();
            MessageBox.Show(desenvolvedor.GetLinguagemProgramacao());
        }
    }
}
