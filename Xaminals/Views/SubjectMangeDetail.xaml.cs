using System;
using Xamarin.Forms;
using KeBei.Models;
using Plugin.Toast;
using Plugin.Toast.Abstractions;

namespace KeBei.Views
{

    public partial class SubjectMangeDetail : ContentPage
    {

        public SubjectMangeDetail()
        {
            InitializeComponent();
        }





        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var subject = (Subject)BindingContext;
            if (subject.Name == null || subject.Name.Trim() == string.Empty)   //如果课程名为空或全为空格 提示输入课程名
            {
                ToastLength toastLength = ToastLength.Short;
                CrossToastPopUp.Current.ShowToastSuccess("请输入课程名", toastLength);
            }
            else
            {
                subject.Name = subject.Name.Trim();                         //去掉课程名首尾的所有空格
                if ((Convert.ToDateTime(subject.EndDate).Subtract(Convert.ToDateTime(DateTime.UtcNow)).Days < -365) ||   //Date不能超过前后一年
                    (Convert.ToDateTime(subject.EndDate).Subtract(Convert.ToDateTime(DateTime.UtcNow)).Days > 365))
                {
                    ToastLength toastLength = ToastLength.Short;
                    CrossToastPopUp.Current.ShowToastSuccess("请输入正确的日期", toastLength);
                }
                else
                {
                    if (subject.CurLenth <= 0)              //课时数必须为正
                    {
                        ToastLength toastLength = ToastLength.Short;
                        CrossToastPopUp.Current.ShowToastSuccess("请输入正确的课时数", toastLength);
                    }
                    else
                    {
                        if (subject.CurLenth > 50)         //课时数不能超过50，若超过则改为50
                        {
                            subject.CurLenth = 50;
                            ToastLength toastLength = ToastLength.Short;
                            CrossToastPopUp.Current.ShowToastSuccess("课时数最多只能为50", toastLength);
                        }
                        await App.Database_Subject.SaveSubjectAsync(subject);

                        for(int i=0;i<subject.CurLenth;i++)
                        {
                            Curriculum curr = new Curriculum();
                            curr.Name = "第" + (i+1).ToString() + "课时";
                            curr.Detail = "点击编辑"+curr.Name+"内容";
                            await App.Database_Curriculum.SaveCurriculumAsync(curr);
                        }


                        await Navigation.PopAsync();
                    }
                }
            }
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var subject = (Subject)BindingContext;
            await App.Database_Subject.DeleteSubjectAsync(subject);
            
            await Navigation.PopAsync();
        }
    }
}