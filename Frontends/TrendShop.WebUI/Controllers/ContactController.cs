﻿using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace TrendShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
//< div class= "col-lg-7 mb-5" >
//    < div class= "contact-form bg-light p-30" >
//        < div id = "success" ></ div >
//        < form name = "sentMessage" id = "contactForm" novalidate = "novalidate" >
//            < div class= "control-group" >
//                < input type = "text" class= "form-control" id = "name" placeholder = "Adınız"
//                       required = "required" data - validation - required - message = "Lütfen adınızı girin" />
//                < p class= "help-block text-danger" ></ p >
//            </ div >
//            < div class= "control-group" >
//                < input type = "email" class= "form-control" id = "email" placeholder = "Email Adresiniz"
//                       required = "required" data - validation - required - message = "Lütfen email adresinizi girin" />
//                < p class= "help-block text-danger" ></ p >
//            </ div >
//            < div class= "control-group" >
//                < input type = "text" class= "form-control" id = "subject" placeholder = "Konu"
//                       required = "required" data - validation - required - message = "Lütfen konuyu giriniz" />
//                < p class= "help-block text-danger" ></ p >
//            </ div >
//            < div class= "control-group" >
//                < textarea class= "form-control" rows = "8" id = "message" placeholder = "Mesaj"
//                          required = "required"
//                          data - validation - required - message = "Lütfen mesajınızı girin" ></ textarea >
//                < p class= "help-block text-danger" ></ p >
//            </ div >
//            < div >
//                < button class= "btn btn-primary py-2 px-4" type = "submit" id = "sendMessageButton" >
//                  Mesajı
//                  Gönder
//                </ button >
//            </ div >
//        </ form >
//    </ div >
//</ div >