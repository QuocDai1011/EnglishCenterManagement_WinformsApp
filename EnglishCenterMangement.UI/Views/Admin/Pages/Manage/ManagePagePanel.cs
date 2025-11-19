using EnglishCenterManagement.Models.Services;
using EnglishCenterMangement.UI.Views.Admin.Pages.Base;
using EnglishCenterMangement.UI.Views.Admin.Utils;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnglishCenterMangement.UI.Views.Admin.Pages.Manage
{
    public partial class ManagePagePanel : BasePagePanel
    {
        public override string PageTitle => "Quản Lý";

        // Các controls có thể kéo thả trong Designer
        private Guna2CirclePictureBox avatarPictureBox;
        private Guna2Button btnEditCover;
        private Guna2TextBox txtCreatePost;

        private readonly IClassService _classService;
        public ManagePagePanel(IClassService classService)
        {
            InitializeComponent();
            setUpEffect();
            _classService = classService;
        }

       
        private void setUpEffect()
        {
            UIHelper.MakeRounded(wrapImage, 200);
            UIHelper.MakeRounded(gnBtnPost, 15);
            UIHelper.MakeRounded(gnBtnIntroduct, 15);
            UIHelper.MakeRounded(gnBtnFile, 15);
            UIHelper.MakeRounded(wrapTabs, 10);
            UIHelper.MakeRounded(pnCreatePost, 80);
            UIHelper.MakeRounded(iBtnImageVideo, 15);
            UIHelper.MakeRounded(gnAvatar, 200);
            UIHelper.MakeRounded(editCoverImage, 20);
            UIHelper.MakeRounded(panelShadow, 10);

        }


    }
}