using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BulkyBookWeb.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class SellerController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public SellerController(IUnitOfWork unitOfWork)
    {
        _unitOfWork= unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Seller> objCoverTypeList = _unitOfWork.Seller.GetAll();
        return View(objCoverTypeList);
    }

    //GET
    public IActionResult Create()
    {
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Seller obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Seller.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "CoverType created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);   
    }

    //GET
    public IActionResult Edit(int? id)
    {
        if(id==null || id == 0)
        {
            return NotFound();
        }
        var CoverTypeFromDbFirst = _unitOfWork.Seller.GetFirstOrDefault(u=>u.Seller_Id==id);

        if (CoverTypeFromDbFirst == null)
        {
            return NotFound();
        }

        return View(CoverTypeFromDbFirst);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Seller obj)
    {
       
        if (ModelState.IsValid)
        {
            _unitOfWork.Seller.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "CoverType updated successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var CoverTypeFromDbFirst = _unitOfWork.Seller.GetFirstOrDefault(u=>u.Seller_Id==id);

        if (CoverTypeFromDbFirst == null)
        {
            return NotFound();
        }

        return View(CoverTypeFromDbFirst);
    }

    //POST
    [HttpPost,ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _unitOfWork.Seller.GetFirstOrDefault(u => u.Seller_Id == id);
        if (obj == null)
        {
            return NotFound();
        }

        _unitOfWork.Seller.Remove(obj);
            _unitOfWork.Save();
        TempData["success"] = "CoverType deleted successfully";
        return RedirectToAction("Index");
        
    }
}
