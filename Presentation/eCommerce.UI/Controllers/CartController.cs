using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Abstract;
using eCommerce.Persistence.Abstract;
using eCommerce.UI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartServices repo;
        private readonly IUserServices userRepo;
        private readonly IOrderServices orderRepo;
        public CartController(ICartServices _repo, IUserServices _userRepo, IOrderServices _orderRepo)
        {
            repo = _repo;
            userRepo = _userRepo;
            orderRepo = _orderRepo;
        }
        public async Task<IActionResult> Index()
        {
            string loggedUser = null;

            if (HttpContext.Session.GetString("loggedUser") != null)
            {
                loggedUser = HttpContext.Session.GetString("loggedUser").ToString();
                var userInfo = await userRepo.GetByUsername(loggedUser);
                if (userInfo != null)
                {
                    var cart = await repo.GetById(userInfo.ID);
                    return View(new CartVM()
                    {
                        ID = cart.ID,
                        userID = cart.userID,
                        CreatedDate = cart.CreatedDate,
                        CartItemList = cart.CartItemList.Select(x => new CartItemModel()
                        {
                            ID = x.ID,
                            productID = x.productID,
                            ImageUrl = x.Product.Image,
                            Name = x.Product.Name,
                            Quantity = x.Quantity,
                            CategoryName = x.Product.category.Title,
                            Price = x.Product.SellerList.Select(x => x.Price).First()
                        }).ToList()
                    });
                }
                return View();
            }
            else
            {
                return RedirectToAction("SignIn", "User");

            }
            return View();
        }
        public async Task<IActionResult> AddtoCart(Guid productID, int quantity)
        {
            string loggedUser = null;

            if (HttpContext.Session.GetString("loggedUser") != null)
            {
                loggedUser = HttpContext.Session.GetString("loggedUser").ToString();
                var userInfo = await userRepo.GetByUsername(loggedUser);
                repo.AddtoCart(userInfo.ID, productID, quantity);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteFromCart(Guid userID, Guid productID)
        {
            string loggedUser = null;

            if (HttpContext.Session.GetString("loggedUser") != null)
            {
                loggedUser = HttpContext.Session.GetString("loggedUser").ToString();
                var userInfo = await userRepo.GetByUsername(loggedUser);
                repo.DeleteFromCart(userInfo.ID, productID);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CheckOut()
        {
            string loggedUser = null;
            var order = new OrderVM();
            if (HttpContext.Session.GetString("loggedUser") != null)
            {
                loggedUser = HttpContext.Session.GetString("loggedUser").ToString();
                var userInfo = await userRepo.GetByUsername(loggedUser);
                if (userInfo != null)
                {
                    var cart = await repo.GetById(userInfo.ID);

                    order.CartModel = new CartVM()
                    {
                        ID = cart.ID,
                        userID = cart.userID,
                        CreatedDate = cart.CreatedDate,
                        CartItemList = cart.CartItemList.Select(x => new CartItemModel()
                        {
                            ID = x.ID,
                            productID = x.productID,
                            ImageUrl = x.Product.Image,
                            Name = x.Product.Name,
                            Quantity = x.Quantity,
                            CategoryName = x.Product.category.Title,
                            Price = x.Product.SellerList.Select(x => x.Price).First()
                        }).ToList()
                    };
                    return View(order);
                }
                return View(order);
            }
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(OrderVM model)
        {
            string loggedUser = null;
            var order = new OrderVM();
            if (HttpContext.Session.GetString("loggedUser") != null)
            {
                loggedUser = HttpContext.Session.GetString("loggedUser").ToString();
                var userInfo = await userRepo.GetByUsername(loggedUser);
                if (userInfo != null)
                {
                    if (ModelState.IsValid)
                    {
                        var cart = await repo.GetById(userInfo.ID);
                        if (model.firstName == null)
                        {
                            order.firstName = userInfo.userInfo.Name;
                        }
                        else
                        {
                            order.firstName = model.firstName;
                        }
                        if (model.lastName == null)
                        {
                            order.lastName = userInfo.userInfo.Surname;
                        }
                        else
                        {
                            order.lastName = model.lastName;
                        }
                        order.OrderNumber = new Random().Next(100000, 666666).ToString();

                        if (model.Address == null)
                        {
                            order.Address = userInfo.userInfo.UserAddress.Address;
                        }
                        else
                        {
                            order.Address = model.Address;
                        }
                        if (model.City == null)
                        {
                            order.City = userInfo.userInfo.UserAddress.City;
                        }
                        else
                        {
                            order.City = model.City;
                        }
                        if (model.Phone == null)
                        {
                            order.Phone = userInfo.userInfo.Phone;
                        }
                        else
                        {
                            order.Phone = model.Phone;
                        }
                        if (model.Email == null)
                        {
                            order.Email = userInfo.userInfo.Email;
                        }
                        else
                        {
                            order.Email = model.Email;
                        }
                        order.Note = model.Note;

                        order.CartModel = new CartVM()
                        {
                            ID = cart.ID,
                            userID = cart.userID,
                            CreatedDate = cart.CreatedDate,
                            CartItemList = cart.CartItemList.Select(x => new CartItemModel()
                            {
                                ID = x.ID,
                                productID = x.productID,
                                ImageUrl = x.Product.Image,
                                Name = x.Product.Name,
                                Quantity = x.Quantity,
                                CategoryName = x.Product.category.Title,
                                Price = x.Product.SellerList.Select(x => x.Price).First()
                            }).ToList()
                        };
                        SaveOrder(order, userInfo.ID);
                        ClearCart(order.CartModel.ID);
                        ViewBag.FullName = model.firstName + " " + model.lastName;
                        return View("SuccessOrder");
                    }
                }
                return View(order);
            }
            return View(order);
        }
        public async Task<IActionResult> GetOrders()
        {
            string loggedUser = null;
            var order = new OrderVM();
            if (HttpContext.Session.GetString("loggedUser") != null)
            {
                loggedUser = HttpContext.Session.GetString("loggedUser").ToString();
                var userInfo = await userRepo.GetByUsername(loggedUser);
                if (userInfo != null)
                {
                    var orders = await orderRepo.GetOrders(userInfo.ID);
                    var orderListModel = new List<OrderListVM>();
                    OrderListVM orderModel;
                    foreach (var item in orders)
                    {
                        orderModel = new OrderListVM();
                        orderModel.Address = item.Address;
                        orderModel.City = item.City;
                        orderModel.Email = item.Email;
                        orderModel.Phone = item.Phone;
                        orderModel.firstName = item.FirstName;
                        orderModel.lastName = item.LastName;
                        orderModel.OrderNumber = item.OrderNumber;
                        orderModel.Note = item.Note;
                        orderModel.OrderItems = item.OrderItems.Select(x => new OrderItemVM()
                        {
                            ID = x.ID,
                            ImageUrl = x.Product.Image,
                            Name = x.Product.Name,
                            Price = x.Price,
                            Quantity = x.Quantity
                        }).ToList();
                        orderListModel.Add(orderModel);
                    }


                    return View("Orders", orderListModel);
                }
            }
            return View();
        }
        private void SaveOrder(OrderVM model, Guid userID)
        {
            var order = new Order();
            order.ID = Guid.NewGuid();
            order.OrderNumber = model.OrderNumber; ;
            order.CreatedDate = DateTime.Now;
            order.orderState = EnumOrderState.completed;
            order.userID = userID;
            order.Address = model.Address;
            order.City = model.City;
            order.FirstName = model.firstName;
            order.LastName = model.lastName;
            order.CreatedDate = DateTime.Now;
            order.Email = model.Email;
            order.Phone = model.Phone;
            order.Note = model.Note;
            order.OrderItems = new List<OrderItem>();
            foreach (var item in model.CartModel.CartItemList)
            {
                var orderItem = new OrderItem()
                {
                    ID = item.ID,
                    CreatedDate = DateTime.Now,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    productID = item.productID
                };
                order.OrderItems.Add(orderItem);
            }
            orderRepo.addOrder(order);
        }
        private void ClearCart(Guid cartID)
        {
            repo.ClearCart(cartID);
        }
    }
}
