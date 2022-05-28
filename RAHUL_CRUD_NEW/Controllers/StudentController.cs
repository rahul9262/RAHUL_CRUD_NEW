using RAHUL_CRUD_NEW.Models;
using RAHUL_CRUD_NEW.Rahul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RAHUL_CRUD_NEW.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
       

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UserModel obj)
        {
            NKHSEntities1 nkhs = new NKHSEntities1();
            var res = nkhs.User_Table.Where(a => a.Email == obj.Email).FirstOrDefault();
            if(res==null)
            {
                TempData["emailnotfound"] = "Eamail Does not Found";
            }
            else
            {
                if(res.Email==obj.Email && res.Password==obj.Password)
                {
                    FormsAuthentication.SetAuthCookie(obj.Email, false);
                    Session["Mail"] = obj.Email.ToString();
                    return RedirectToAction("Index", "Student");
                }
                else
                {

                    TempData["password"] = "Password Does not Match";
                   
                }
              
            }
            return View();
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Student");
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult AddUser(UserModel obj)
        {
            NKHSEntities1 nkhs = new NKHSEntities1();
            User_Table ut = new User_Table();
            ut.Userid = obj.Userid;
            ut.Name = obj.Name;
            ut.Email = obj.Email;
            ut.Password = obj.Password;
            ut.MobIle= obj.MobIle;
            nkhs.User_Table.Add(ut);
            nkhs.SaveChanges();
           
            return RedirectToAction("Login","Student");

        }
        // GET: Student     
        public ActionResult Index()
        {
            /* List<StudentModel> sm = new List<StudentModel>();
             NKHSEntities1 nkhs = new NKHSEntities1();
             var res = nkhs.Stu_Table.ToList();
             foreach (var item in res)
             {
                 sm.Add(new StudentModel
                 {
                     RollNo = item.RollNo,
                     Name=item.Name,
                     Class=item.Class,
                     Mobile=item.Mobile,
                     P_Marks=item.P_Marks,
                     T_Marks=item.T_Marks,
                     Add=item.Add

                 }) ;
             }*/
            NKHSEntities1 nkhs = new NKHSEntities1();
            var res = nkhs.Stu_Table.ToList();
            return View(res);
        }
        [HttpGet]
      
        public ActionResult AddStudent()
        {

            return View();
        }
        [HttpPost]
     
        [ValidateAntiForgeryToken()]
        public ActionResult AddStudent(StudentModel obj)
        {
            NKHSEntities1 nkhs = new NKHSEntities1();
            Stu_Table st = new Stu_Table();
           st.RollNo = obj.RollNo;
            st.Name = obj.Name;
            st.Class = obj.Class;
            st.Mobile = obj.Mobile;
            st.P_Marks = obj.P_Marks;
            st.T_Marks = obj.T_Marks;
            st.Add = obj.Add;
            if(st.RollNo == 0)
            {
                nkhs.Stu_Table.Add(st);
                nkhs.SaveChanges();
            }
            else
            {
                nkhs.Entry(st).State = System.Data.Entity.EntityState.Modified;
                nkhs.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int RollNo)
        {
            NKHSEntities1 nkhs = new NKHSEntities1();
            var del = nkhs.Stu_Table.Where(m => m.RollNo == RollNo).First();
            nkhs.Stu_Table.Remove(del);
            nkhs.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int RollNo)
        {
            NKHSEntities1 nkhs = new NKHSEntities1();
            StudentModel studentModel = new StudentModel();
            var edit = nkhs.Stu_Table.Where(n => n.RollNo == RollNo).First();
            studentModel.RollNo = edit.RollNo;
            studentModel.Name = edit.Name;
            studentModel.Class = edit.Class;
            studentModel.Mobile = edit.Mobile;
            studentModel.P_Marks = edit.P_Marks;
            studentModel.T_Marks = edit.T_Marks;
             studentModel.Add = edit.Add;
            ViewBag.edit = "Edit";

            return View("AddStudent", studentModel);
        }
    }
    }