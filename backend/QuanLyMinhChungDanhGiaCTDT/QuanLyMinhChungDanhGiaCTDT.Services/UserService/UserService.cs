using AdminApp.Shared.ExtentionMethod;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuanLyMinhChungDanhGiaCTDT.EntityFramework;
using QuanLyMinhChungDanhGiaCTDT.EntityFramework.Entity.Identity;
using QuanLyMinhChungDanhGiaCTDT.Models.EFModels.UserModel;
using QuanLyMinhChungDanhGiaCTDT.Models.ResultModels;
using QuanLyMinhChungDanhGiaCTDT.Services.UserService.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMinhChungDanhGiaCTDT.Services.UserService
{
    public class UserService : IUserService
    {
        public readonly EFDbContext _EFDbContext;
        public readonly UserManager<MyIdentityUser> _UserManager;
        public readonly SignInManager<MyIdentityUser> _SignInManager;
        public readonly RoleManager<MyIdentityRole> _RoleManager;
        public readonly IConfiguration _IConfiguration;
        public readonly IMapper _IMapper;

        public UserService(EFDbContext myIdentityDbContext,
            UserManager<MyIdentityUser> userManager,
            SignInManager<MyIdentityUser> signInManager,
            RoleManager<MyIdentityRole> roleManager,
            IConfiguration iConfiguration,
            IMapper iMapper)
        {
            this._EFDbContext = myIdentityDbContext;
            this._UserManager = userManager;
            this._SignInManager = signInManager;
            this._RoleManager = roleManager;
            this._IConfiguration = iConfiguration;
            this._IMapper = iMapper;
        }

        //public Task<MyServiceResult> ChangeActiveUser(string userId, bool isActive)
        //{
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(userId))
        //        {
        //            return new MyServiceResult
        //            {
        //                Successed = false,
        //                Content = "User does not exist"
        //            };
        //        }
        //        MyIdentityUser objMyIdentityUser = await this._UserManager.FindByIdAsync(userId);
        //        if (objMyIdentityUser is null)
        //        {
        //            return new MyServiceResult
        //            {
        //                Successed = false,
        //                Content = "User does not exist",
        //                Token = ""
        //            };
        //        }
        //        objMyIdentityUser.IsActive = isActive;
        //        int saveChangeResult = await this._MyIdentityDbContext.SaveChangesAsync();
        //        if (saveChangeResult > 0)
        //        {
        //            return new MyServiceResult
        //            {
        //                Successed = true,
        //                Content = "Change active user success"
        //            };
        //        }
        //        else
        //        {
        //            return new MyServiceResult
        //            {
        //                Successed = false,
        //                Content = "Change active user fail"
        //            };
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public async Task<MyServiceResult> Delete(string userId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userId))
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Người dùng không tồn tại"
                    };
                }
                MyIdentityUser objMyIdentityUser = await this._UserManager.FindByIdAsync(userId);
                if (objMyIdentityUser is null)
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Người dùng không tồn tại"
                    };
                }

                this._EFDbContext.Users.Remove(objMyIdentityUser);
                int saveChangeResult = await this._EFDbContext.SaveChangesAsync();
                if (saveChangeResult > 0)
                {
                    return new MyServiceResult
                    {
                        Successed = true,
                        Content = $"Xoá người dùng {objMyIdentityUser.UserName} thành công"
                    };
                }
                else
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = $"Xoá người dùng {objMyIdentityUser.UserName} thất bại"
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MyServiceListObjectResult<MyUserInfoModel>> GetAll()
        {
            try
            {
                IEnumerable<MyUserInfoModel> iEnumerableCUserModel = await this._EFDbContext.Users.Select(item => this._IMapper.Map<MyUserInfoModel>(item)).ToListAsync();
                return new MyServiceListObjectResult<MyUserInfoModel>
                {
                    Successed = true,
                    Content="Lấy danh sách Người dùng thành công",
                    ListObject = iEnumerableCUserModel
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MyServiceListObjectResult<MyRoleInfoModel>> GetAllRole()
        {
            try
            {
                List<MyRoleInfoModel> roleList = await _RoleManager.Roles.Select(item => new MyRoleInfoModel { MaChucVu = item.Id.ToString(), TenChucVu = item.Name, MoTa = item.Description }).ToListAsync();
                return new MyServiceListObjectResult<MyRoleInfoModel>
                {
                    Successed = true,
                    Content = "Lấy danh sách Chức vụ thành công",
                    ListObject = roleList
                };
            }
            catch (Exception ex)
            {
                return new MyServiceListObjectResult<MyRoleInfoModel>
                {
                    Successed = false,
                    Content = ex.Message
                };
            }
        }

        public async Task<MyServiceObjectResult<MyUserInfoModel>> GetInformation(string userId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userId))
                {
                    return new MyServiceObjectResult<MyUserInfoModel>
                    {
                        Successed = false,
                        Content = "Người dùng không tồn tại"
                    };
                }
                MyIdentityUser objMyIdentityUser = await this._UserManager.FindByIdAsync(userId);
                if (objMyIdentityUser is null)
                {
                    return new MyServiceObjectResult<MyUserInfoModel>
                    {
                        Successed = false,
                        Content = "Người dùng không tồn tại"
                    };
                }
                MyUserInfoModel CUserModel = this._IMapper.Map<MyUserInfoModel>(objMyIdentityUser);
                return new MyServiceObjectResult<MyUserInfoModel>
                {
                    Successed = true,
                    Content = "Lấy thông tin thành công",
                    Object = CUserModel
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MyServiceResult> ResetPassword(string userId, string newPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userId))
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Người dùng không tồn tại"
                    };
                }
                MyIdentityUser objMyIdentityUser = await this._UserManager.FindByIdAsync(userId);
                if (objMyIdentityUser is null)
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Người dùng không tồn tại"
                    };
                }

                IdentityResult objIdentityResultRemove = await this._UserManager.RemovePasswordAsync(objMyIdentityUser);
                if (objIdentityResultRemove.Succeeded)
                {
                    IdentityResult objIdentityResultAdd = await this._UserManager.AddPasswordAsync(objMyIdentityUser, newPassword);
                    if (objIdentityResultAdd.Succeeded)
                    {
                        return new MyServiceResult
                        {
                            Successed = true,
                            Content = "Đặt lại mật khẩu thành công"
                        };
                    }
                    else
                    {
                        return new MyServiceResult
                        {
                            Successed = false,
                            Content = "Đặt lại mật khẩu thất bại"
                        };
                    }
                }
                else
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Đặt lại mật khẩu thất bại"
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MySignInResult> SignIn(MySignInModel model)
        {
            try
            {
                if (model is null)
                {
                    return new MySignInResult
                    {
                        Successed = false,
                        Content = "Lỗi đăng nhập",
                        Tokens = "",
                        UserInfo = null
                    };
                }
                MyIdentityUser objMyIdentityUser = await this._UserManager.FindByNameAsync(model.UserName);
                if (objMyIdentityUser is null)
                {
                    return new MySignInResult
                    {
                        Successed = false,
                        Content = "Người dùng không tồn tại",
                        Tokens = "",
                        UserInfo = null
                    };
                }

                SignInResult objSignInResult = await this._SignInManager.PasswordSignInAsync(objMyIdentityUser, model.Password, model.Remember, true);
                if (objSignInResult.Succeeded)
                {
                    string jwt = await GenerateJWT(objMyIdentityUser);
                    return new MySignInResult
                    {
                        Successed = true,
                        Content = "Đăng nhập thành công",
                        Tokens = jwt,
                        UserInfo = _IMapper.Map<MyUserInfoModel>(objMyIdentityUser)
                    };
                }
                else
                {
                    return new MySignInResult
                    {
                        Successed = false,
                        Content = "Đăng nhập thât bại",
                        Tokens = "",
                        UserInfo = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new MySignInResult
                {
                    Successed = false,
                    Content = ex.Message,
                    Tokens = "",
                    UserInfo = null
                };
            }
        }

        public async Task<MyServiceResult> SignUp(MySignUpModel model)
        {
            try
            {
                if (model is null)
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Lỗi đăng ký"
                    };
                }

                MyIdentityUser objMyIdentityUserFind = await this._UserManager.FindByNameAsync(model.UserName);
                if (objMyIdentityUserFind is null)
                {
                    MyIdentityUser objMyIdentityUserCreate = this._IMapper.Map<MyIdentityUser>(model);
                    IdentityResult objIdentityResult = await this._UserManager.CreateAsync(objMyIdentityUserCreate, model.Password);
                    if (objIdentityResult.Succeeded)
                    {
                        string roleName = "";
                        if (string.IsNullOrWhiteSpace(model.RoleId))
                        {
                            string formatRoleString = model.RoleName.CapitalizeSentences();
                            bool existsRole = await this._RoleManager.RoleExistsAsync(formatRoleString);
                            if (existsRole == false)
                            {
                                await this._RoleManager.CreateAsync(new MyIdentityRole
                                {
                                    Name = model.RoleName
                                });
                                roleName = formatRoleString;
                            }
                        }
                        else
                        {
                            MyIdentityRole objMyIdentityRole = await this._RoleManager.FindByIdAsync(model.RoleId);
                            if (objIdentityResult is null)
                            {
                                return new MyServiceResult
                                {
                                    Successed = false,
                                    Content = "Đăng ký thất bại"
                                };
                            }
                            roleName = objMyIdentityRole.Name;
                        }
                        IdentityResult objIdentityResultAddRole = await this._UserManager.AddToRoleAsync(objMyIdentityUserCreate, roleName);
                        if (objIdentityResultAddRole.Succeeded)
                        {
                            return new MyServiceResult
                            {
                                Successed = true,
                                Content = "Đăng ký thành công"
                            };
                        }
                        else
                        {
                            return new MyServiceResult
                            {
                                Successed = false,
                                Content = "Đăng ký thất bại"
                            };
                        }
                    }
                    else
                    {
                        return new MyServiceResult
                        {
                            Successed = false,
                            Content = "Đăng ký thất bại"
                        };
                    }
                }
                else
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Người dùng đã tồn tại"
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MyServiceResult> UpdateInformation(string userId, MyUpdateUserModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userId))
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Người dùng không tồn tại"
                    };
                }
                MyIdentityUser objMyIdentityUser = await this._UserManager.FindByIdAsync(userId);
                if (objMyIdentityUser is null)
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Người dùng không tồn tại",
                    };
                }

                MyIdentityUser objMyIdentityUserNew = this._IMapper.Map<MyUpdateUserModel, MyIdentityUser>(model, objMyIdentityUser);
                this._EFDbContext.Entry<MyIdentityUser>(objMyIdentityUserNew).State = EntityState.Modified;
                int saveChangeResult = await this._EFDbContext.SaveChangesAsync();
                if (saveChangeResult > 0)
                {
                    MyIdentityUser objMyIdentityUser1 = await this._UserManager.FindByIdAsync(userId);
                    if (objMyIdentityUser1 is null)
                    {
                        return new MyServiceResult
                        {
                            Successed = false,
                            Content = "Người dùng không tồn tại",
                        };
                    }

                    if (!string.IsNullOrEmpty(model.Role))
                    {
                        bool isExistRole = await _RoleManager.RoleExistsAsync(model.Role);
                        if (isExistRole)
                        {
                            IList<string> iListRole = await _UserManager.GetRolesAsync(objMyIdentityUser1);
                            string roleUser = iListRole.First();
                            if (iListRole.Count > 0 && !string.Equals(roleUser, model.Role))
                            {
                                IdentityResult resultRemoveRole = await _UserManager.RemoveFromRoleAsync(objMyIdentityUser1, roleUser);
                                if (resultRemoveRole.Succeeded)
                                {
                                    MyIdentityRole objMyIdentityRole = await _RoleManager.FindByIdAsync(model.Role);
                                    IdentityResult resultAddNewRole = await _UserManager.AddToRoleAsync(objMyIdentityUser1, objMyIdentityRole.Name);
                                    if (resultAddNewRole.Succeeded)
                                    {
                                        return new MyServiceResult
                                        {
                                            Successed = true,
                                            Content = "Cập nhật thông tin người dùng thành công"
                                        };
                                    }
                                    else
                                    {
                                        return new MyServiceResult
                                        {
                                            Successed = false,
                                            Content = "Cập nhật thông tin người dùng thất bại"
                                        };
                                    }
                                }
                            }
                        }
                    }
                    return new MyServiceResult
                    {
                        Successed = true,
                        Content = "Cập nhật thông tin người dùng thành công"
                    };
                }
                else
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Cập nhật thông tin người dùng thất bại"
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<string> GenerateJWT(MyIdentityUser user)
        {
            try
            {
                IList<string> iListRoleUser = await this._UserManager.GetRolesAsync(user);

                List<Claim> listClaimUser = new List<Claim>
                {
                    new Claim("MaNguoiDung", user.Id.ToString()),
                    new Claim("TenDangNhap", user.UserName),
                    new Claim("HoTen", user.FullName),
                    new Claim("SoDienThoai", user.PhoneNumber),
                    new Claim("NgaySinh", user.DateOfBirth?.ToString()??"Trống"),
                    new Claim("Email", user.Email),
                    new Claim("DiaChi", user.Address??"Trống"),
                };

                string roleUser = iListRoleUser.First();
                listClaimUser.Add(new Claim(ClaimTypes.Role, roleUser));
                listClaimUser.Add(new Claim("ChucVu", roleUser));
                string key = _IConfiguration["JWT:Key"];
                string issuer = _IConfiguration["JWT:Issuer"];
                SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
                JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer, issuer, listClaimUser, expires: DateTime.Now.AddHours(1), signingCredentials: signingCredentials);
                string jwt = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                return await Task.FromResult<string>(jwt);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}