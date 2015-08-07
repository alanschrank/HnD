﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SD.HnD.Gui
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			// This informs MVC Routing Engine to send any requests for .aspx page to the WebForms engine
			routes.IgnoreRoute("{resource}.aspx/{*pathInfo}");
			routes.IgnoreRoute("{resource}.aspx");

			routes.MapRoute("ToggleMarkAsDone", "Thread/ToggleMarkAsDone/{id}/{pageNo}", new { controller = "Thread", action = "ToggleMarkAsDone", id = UrlParameter.Optional, pageNo = 1 });
			routes.MapRoute("ToggleBookmark", "Thread/ToggleBookmark/{id}", new { controller = "Thread", action = "ToggleBookmark", id = UrlParameter.Optional });
			routes.MapRoute("ToggleSubscribe", "Thread/ToggleSubscribe/{id}", new { controller = "Thread", action = "ToggleSubscribe", id = UrlParameter.Optional });
			routes.MapRoute("MoveThread", "Thread/Move/{id}", new { controller = "Thread", action = "Move", id = UrlParameter.Optional });
			routes.MapRoute("DeleteThread", "Thread/Delete/{id}", new { controller = "Thread", action = "Delete", id = UrlParameter.Optional });
			routes.MapRoute("ViewThread", "Thread/{id}/{pageNo}", new { controller = "Thread", action = "Index", id = UrlParameter.Optional, pageNo = 1 });

			routes.MapRoute("ViewForum", "Forum/{id}/{pageNo}", new { controller="Forum", action="Index", id = UrlParameter.Optional, pageNo=1 });
			routes.MapRoute("RssForum", "RssForum/{id}", new {controller = "RssForum", action = "Index", id = UrlParameter.Optional});

			routes.MapRoute("MoveToQueue", "SupportQueue/MoveToQueue/{id}/{pageNo}", new { controller = "SupportQueue", action="MoveToQueue", id = UrlParameter.Optional, pageNo = 1 });
			routes.MapRoute("ClaimThread", "SupportQueue/ClaimThread/{id}/{pageNo}", new { controller = "SupportQueue", action = "ClaimThread", id = UrlParameter.Optional, pageNo = 1 });
			routes.MapRoute("ReleaseThread", "SupportQueue/ReleaseThread/{id}/{pageNo}", new { controller = "SupportQueue", action = "ReleaseThread", id = UrlParameter.Optional, pageNo = 1 });
			routes.MapRoute("EditMemo", "SupportQueue/EditMemo/{id}/{pageNo}", new {controller = "SupportQueue", action = "EditMemo", id = UrlParameter.Optional, pageNo = 1});

			routes.MapRoute("DeleteMessage", "Message/Delete/{id}", new {controller = "Message", action = "Delete", id = UrlParameter.Optional});
			routes.MapRoute("ListOfForums", "Section/Forums/{id}", new {controller = "Section", action = "Forums", id = UrlParameter.Optional});
			
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
