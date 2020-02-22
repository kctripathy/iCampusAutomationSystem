using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Net.Http;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;


namespace Micro.WebApplication
{
	public class Global : System.Web.HttpApplication
	{

		void Application_Start(object sender, EventArgs e)
		{
			// Code that runs on application startup
			RouteTable.Routes.MapHttpRoute(
					name: "DefaultApi",
					routeTemplate: "api/{controller}/{id}",
					defaults: new { id = System.Web.Http.RouteParameter.Optional }
			);

			

			RegisterRoutes(RouteTable.Routes);
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			
			routes.MapPageRoute("about", "about", "~/icas/about.aspx");
            routes.MapPageRoute("", "about-{thePage}", "~/icas/about.aspx");

            routes.MapPageRoute("crest", "crest", "~/icas/about.aspx");
            routes.MapPageRoute("history", "history", "~/icas/about.aspx");
			routes.MapPageRoute("vision", "vision", "~/icas/about.aspx");
			routes.MapPageRoute("mission", "mission", "~/icas/about.aspx");
			routes.MapPageRoute("vision-mission", "vision-mission", "~/icas/about.aspx");

			routes.MapPageRoute("rules", "rules", "~/icas/about.aspx");
            routes.MapPageRoute("ncc", "ncc", "~/icas/about.aspx?Page=ncc");
			routes.MapPageRoute("location", "location", "~/icas/about.aspx?Page=location");
            routes.MapPageRoute("library", "library", "~/icas/about.aspx?Page=about-library");
            routes.MapPageRoute("holidays", "holidays", "~/icas/about.aspx?Page=holidays");
            routes.MapPageRoute("rti", "rti", "~/icas/about.aspx?Page=rti");
            routes.MapPageRoute("links", "links", "~/icas/about.aspx?Page=best-links");
            routes.MapPageRoute("downloads", "downloads", "~/downloads.aspx");
            routes.MapPageRoute("contact", "contact", "~/ContactUs.aspx");
            routes.MapPageRoute("photo", "photo", "~/photogallery.aspx");
            routes.MapPageRoute("photo-gallery", "photo-gallery", "~/photogallery.aspx");
            
            //routes.MapPageRoute("video", "video", "~/videogallery.aspx");
            routes.MapPageRoute("video-gallery", "video-gallery", "~/photogallery.aspx");

            routes.MapPageRoute("register", "register", "~/Students.aspx");
            routes.MapPageRoute("login", "login", "~/Apps/UserLogin.aspx");
			routes.MapPageRoute("logout", "logout", "~/Apps/Logout.aspx");
			
			//activity
            routes.MapPageRoute("activity", "activity", "~/icas/activties.aspx");
            routes.MapPageRoute("", "activity-{thePage}", "~/icas/activties.aspx");

            //staffs
			routes.MapPageRoute("staffs", "staffs", "~/icas/staffs.aspx");
			routes.MapPageRoute("", "staffs-teaching", "~/ICAS/staffs.aspx?Category=T");
			routes.MapPageRoute("", "staffs-non-teaching", "~/ICAS/staffs.aspx?Category=N");
            routes.MapPageRoute("staff", "staff-{thePage}", "~/icas/about.aspx");
			routes.MapPageRoute("", "staff-{theStudentName}", "~/icas/about.aspx");
			routes.MapPageRoute("", "staff-{thePhoneNo}", "~/icas/about.aspx");
			routes.MapPageRoute("principals-list", "principals-list", "~/icas/about.aspx");
			routes.MapPageRoute("principal-message", "principal-message", "~/icas/about.aspx");

			//students
            routes.MapPageRoute("students", "students", "~/icas/students.aspx");
			routes.MapPageRoute("student", "students-{thePage}", "~/icas/about.aspx");
			routes.MapPageRoute("college", "college-{thePage}", "~/icas/about.aspx");
            routes.MapPageRoute("exam-result", "exam-result", "~/icas/student/examresults.aspx");

            

			//routes.MapPageRoute("", "students-union", "~/icas/about.aspx");
			routes.MapPageRoute("", "student-{theStudentName}", "~/icas/about.aspx");
			routes.MapPageRoute("", "student-{thePhoneNo}", "~/icas/about.aspx");
			routes.MapPageRoute("", "student-feedback", "~/apps/icas/admin/studentfeedback.aspx");

			
			routes.MapPageRoute("feedback", "feedback", "~/apps/icas/admin/studentfeedback.aspx");

			routes.MapPageRoute("alumnis", "alumnis", "~/icas/about.aspx");
			routes.MapPageRoute("alumni", "alumni-{thePage}", "~/icas/about.aspx");
			routes.MapPageRoute("", "alumni-{theStudentName}", "~/icas/about.aspx");
			routes.MapPageRoute("", "alumni-{thePhoneNo}", "~/icas/about.aspx");
            
            //admin
            routes.MapPageRoute("portfolio", "portfolio", "~/icas/about.aspx?Page=portfolio");
            routes.MapPageRoute("governing-body", "governing-body", "~/icas/about.aspx?Page=governing-body");
            routes.MapPageRoute("minutes", "minutes", "~/MinutesOfMeeting.aspx?of=gb");
            routes.MapPageRoute("mom", "mom", "~/MinutesOfMeeting.aspx?of=gb");
            
            //academic
            routes.MapPageRoute("departments", "departments", "~/icas/about.aspx?Page=departments");
            //routes.MapPageRoute("department-", "department-", "~/icas/about.aspx?Page=department-");

            routes.MapPageRoute("department-odia", "department-odia", "~/icas/about.aspx?Page=department-odia");
            routes.MapPageRoute("department-english", "department-english", "~/icas/about.aspx?Page=department-english");
            routes.MapPageRoute("department-physics", "department-physics", "~/icas/about.aspx?Page=department-physics");
            routes.MapPageRoute("department-chemistry", "department-chemistry", "~/icas/about.aspx?Page=department-chemistry");
            routes.MapPageRoute("department-botany", "department-botany", "~/icas/about.aspx?Page=department-botany");
            routes.MapPageRoute("department-zoology", "department-zoology", "~/icas/about.aspx?Page=department-zoology");
            routes.MapPageRoute("department-it", "department-it", "~/icas/about.aspx?Page=department-it");
            routes.MapPageRoute("department-economics", "department-economics", "~/icas/about.aspx?Page=department-economics");
            routes.MapPageRoute("department-political-science", "department-political-science", "~/icas/about.aspx?Page=department-political-science");
            routes.MapPageRoute("department-history", "department-history", "~/icas/about.aspx?Page=department-history");
            routes.MapPageRoute("department-mathmatics", "department-mathmatics", "~/icas/about.aspx?Page=department-mathmatics");
            routes.MapPageRoute("department-logic", "department-", "~/icas/about.aspx?Page=department-logic");
            routes.MapPageRoute("department-philoshophy", "department-", "~/icas/about.aspx?Page=department-");
            routes.MapPageRoute("department-education", "department-", "~/icas/about.aspx?Page=department-");
            routes.MapPageRoute("department-yoga", "department-", "~/icas/about.aspx?Page=department-yoga");
            routes.MapPageRoute("vocational-subjects", "vocational-subjects-", "~/icas/about.aspx?Page=vocational-subjects");
            routes.MapPageRoute("management", "management", "~/icas/about.aspx?Page=management");
            routes.MapPageRoute("garden", "garden", "~/icas/about.aspx?Page=garden");
            routes.MapPageRoute("minutes-of-meetings", "minutes-of-meetings", "~/MinutesOfMeetings.aspx");

			routes.MapPageRoute("transactions", "Library/transactions-view", "~/Library/Transactions.aspx");
			routes.MapPageRoute("transaction", "Library/transaction-{theTransaction}", "~/Library/Transactions.aspx");
			routes.MapPageRoute("transaction-user", "Library/transaction-{theTransaction}-{theUserType}", "~/Library/Transactions.aspx");
			routes.MapPageRoute("books", "Library/books", "~/Library/Books.aspx");
			routes.MapPageRoute("book", "Library/book-{theTransaction}", "~/Library/Transactions.aspx");
			routes.MapPageRoute("book-user", "Library/book-{theTransaction}-{theUserType}", "~/Library/Transactions.aspx");
			routes.MapPageRoute("books-manage", "Library/books", "~/Library/BooksManage.aspx");
			
			routes.MapPageRoute("kishor", "kishor", "~/Kishor.aspx");
			 
		}

		void Application_End(object sender, EventArgs e)
		{
			//  Code that runs on application shutdown

		}

		void Application_Error(object sender, EventArgs e)
		{
			// Code that runs when an unhandled error occurs

		}

		void Session_Start(object sender, EventArgs e)
		{
			// Code that runs when a new session is started
			HttpContext.Current.Session.Clear();
		}

		void Session_End(object sender, EventArgs e)
		{
			// Code that runs when a session ends. 
			// Note: The Session_End event is raised only when the sessionstate mode
			// is set to InProc in the Web.config file. If session mode is set to StateServer 
			// or SQLServer, the event is not raised.
			//HttpContext.Current.Session.Clear();

		}

	}
}
