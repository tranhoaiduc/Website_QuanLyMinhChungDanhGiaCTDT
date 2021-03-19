using QuanLyMinhChungDanhGiaCTDT.Dapper.Dapper.Interface;
using QuanLyMinhChungDanhGiaCTDT.Models.DapperModels.MinhChungModel;
using QuanLyMinhChungDanhGiaCTDT.Models.ResultModels;
using QuanLyMinhChungDanhGiaCTDT.Services.MinhChungService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyMinhChungDanhGiaCTDT.Models.DapperModels.TieuChuanModel;
using Dapper;

namespace QuanLyMinhChungDanhGiaCTDT.Services.MinhChungService
{
    public class MinhChungService : IMinhChungService
    {
        private readonly IMyDapper _IMyDapper;

        public MinhChungService(IMyDapper iMyDapper)
        {
            this._IMyDapper = iMyDapper;
        }

        public async Task<MyServiceResult> CapNhat(string maMinhChung, CapNhatMinhChungDPEntity model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maMinhChung))
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Lỗi cập nhật Minh chứng"
                    };
                }

                if (model is null)
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Lỗi cập nhật Minh chứng"
                    };
                }

                IDbConnection dbConnection = _IMyDapper.GetConnection();
                if (dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection.Open();
                }

                using (IDbTransaction dbTransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        MinhChungDPEntity objMinhChungDPEntity = await dbConnection.QueryFirstOrDefaultAsync<MinhChungDPEntity>("[LayMinhChungTheoMa]", new { @MaMinhChung = maMinhChung }, transaction: dbTransaction, commandType: CommandType.StoredProcedure);

                        if (objMinhChungDPEntity is null)
                        {
                            return new MyServiceResult
                            {
                                Successed = false,
                                Content = "Không tìm thấy Minh chứng"
                            };
                        }

                        int effectedRows = await dbConnection.ExecuteAsync("[CapNhatMinhChung]", new { @MaMinhChung = maMinhChung, @SoKyHieu = model.SoKyHieu, @TrichYeu = model.TrichYeu, @CoQuanBanHanh = model.CoQuanBanHanh, @NoiNhanCacVanBan = model.NoiNhanCacVanBan, @NoiLuuBanChinh = model.NoiLuuBanChinh, @MucDo = model.MucDo, @NguoiKyVanBan = model.NguoiKyVanBan, @SoPhatHanh = model.SoPhatHanh, @LinhVucVanBan = model.LinhVucVanBan, @LoaiVanBan = model.LoaiVanBan, @MaNguoiTao = model.MaNguoiTao, @MaTieuChi = model.MaTieuChi, @MaTieuChuan = model.MaTieuChuan }, transaction: dbTransaction, commandType: CommandType.StoredProcedure);
                        dbTransaction.Commit();
                        if (effectedRows > 0)
                        {
                            return new MyServiceResult
                            {
                                Successed = true,
                                Content = $"Cập nhật thành công Minh chứng {objMinhChungDPEntity.MaMinhChung}"
                            };
                        }
                        else
                        {
                            return new MyServiceResult
                            {
                                Successed = false,
                                Content = $"Cập nhật thất bại Minh chứng {objMinhChungDPEntity.MaMinhChung}"
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new MyServiceResult
                        {
                            Successed = false,
                            Content = ex.Message
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new MyServiceResult
                {
                    Successed = false,
                    Content = ex.Message
                };
            }
        }

        public async Task<MyServiceListObjectResult<MinhChungDPEntity>> LayDanhSach()
        {
            try
            {
                IDbConnection dbConnection = _IMyDapper.GetConnection();
                if (dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection.Open();
                }

                using (IDbTransaction iDbTransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        IEnumerable<MinhChungDPEntity> enumerableMinhChungDPEntity = await dbConnection.QueryAsync<MinhChungDPEntity>("[LayDanhSachMinhChung]", transaction: iDbTransaction, commandType: CommandType.StoredProcedure);
                        iDbTransaction.Commit();
                        return new MyServiceListObjectResult<MinhChungDPEntity>
                        {
                            Successed = true,
                            Content = "Lấy danh sách Minh chứng thành công",
                            ListObject = enumerableMinhChungDPEntity
                        };
                    }
                    catch (Exception ex)
                    {
                        iDbTransaction.Rollback();
                        return new MyServiceListObjectResult<MinhChungDPEntity>
                        {
                            Successed = false,
                            Content = ex.Message
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new MyServiceListObjectResult<MinhChungDPEntity>
                {
                    Successed = false,
                    Content = ex.Message
                };
            }
        }

        public async Task<MyServiceObjectResult<MinhChungDPEntity>> LayTheoMa(string maMinhChung)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maMinhChung))
                {
                    return new MyServiceObjectResult<MinhChungDPEntity>
                    {
                        Successed = false,
                        Content = "Lỗi lấy Minh chứng"
                    };
                }

                IDbConnection dbConnection = _IMyDapper.GetConnection();
                if (dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection.Open();
                }

                using (IDbTransaction iDbTransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        MinhChungDPEntity objMinhChungDPEntity = await dbConnection.QueryFirstOrDefaultAsync<MinhChungDPEntity>("[LayMinhChungTheoMa]", new { @MaMinhChung = maMinhChung }, transaction: iDbTransaction, commandType: CommandType.StoredProcedure);

                        iDbTransaction.Commit();
                        if (objMinhChungDPEntity is null)
                        {
                            return new MyServiceObjectResult<MinhChungDPEntity>
                            {
                                Successed = false,
                                Content = "Không tìm thấy Minh chứng",
                                Object = null
                            };
                        }
                        else
                        {
                            return new MyServiceObjectResult<MinhChungDPEntity>
                            {
                                Successed = true,
                                Content = "Lấy Minh chứng thành công",
                                Object = objMinhChungDPEntity
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        iDbTransaction.Rollback();
                        return new MyServiceObjectResult<MinhChungDPEntity>
                        {
                            Successed = false,
                            Content = ex.Message
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new MyServiceObjectResult<MinhChungDPEntity>
                {
                    Successed = false,
                    Content = ex.Message
                };
            }
        }

        public async Task<MyServiceResult> Tao(TaoMinhChungDPEntity model)
        {
            try
            {
                if (model is null)
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Lỗi tạo Minh chứng"
                    };
                }

                IDbConnection dbConnection = _IMyDapper.GetConnection();
                if (dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection.Open();
                }
                using (IDbTransaction dbTransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        int effectedRows = await dbConnection.ExecuteAsync("[TaoMinhChung]", new { @MaMinhChung = model.MaMinhChung, @SoKyHieu = model.SoKyHieu, @TrichYeu = model.TrichYeu, @CoQuanBanHanh = model.CoQuanBanHanh, @NoiNhanCacVanBan = model.NoiNhanCacVanBan, @NoiLuuBanChinh = model.NoiLuuBanChinh, @MucDo = model.MucDo, @NguoiKyVanBan = model.NguoiKyVanBan, @SoPhatHanh = model.SoPhatHanh, @LinhVucVanBan = model.LinhVucVanBan, @LoaiVanBan = model.LoaiVanBan, @NgayTao = model.NgayTao, @NgayLuu = DateTime.Now, @MaNguoiTao = model.MaNguoiTao, @MaTieuChi = model.MaTieuChi, @MaTieuChuan = model.MaTieuChuan }, transaction: dbTransaction, commandType: CommandType.StoredProcedure);
                        dbTransaction.Commit();
                        if (effectedRows > 0)
                        {
                            return new MyServiceResult
                            {
                                Successed = true,
                                Content = $"Tạo thành công Minh chứng {model.MaMinhChung}"
                            };
                        }
                        else
                        {
                            return new MyServiceResult
                            {
                                Successed = false,
                                Content = $"Tạo thất bại Minh chứng {model.MaMinhChung}"
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new MyServiceResult
                        {
                            Successed = false,
                            Content = ex.Message
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new MyServiceResult
                {
                    Successed = false,
                    Content = ex.Message
                };
            }
        }

        public async Task<MyServiceResult> Xoa(string maMinhChung)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maMinhChung))
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Lỗi xoá Minh chứng"
                    };
                }

                IDbConnection dbConnection = _IMyDapper.GetConnection();
                if (dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection.Open();
                }

                using (IDbTransaction dbTransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        MinhChungDPEntity objMinhChungDPEntity = await dbConnection.QueryFirstOrDefaultAsync<MinhChungDPEntity>("[LayMinhChungTheoMa]", new { @MaMinhChung = maMinhChung }, transaction: dbTransaction, commandType: CommandType.StoredProcedure);
                        if (objMinhChungDPEntity is null)
                        {
                            return new MyServiceResult
                            {
                                Successed = false,
                                Content = "Không tìm thấy Minh chứng"
                            };
                        }

                        int effectedRows = await dbConnection.ExecuteAsync("[XoaMinhChung]", new { @MaMinhChung = maMinhChung }, transaction: dbTransaction, commandType: CommandType.StoredProcedure);
                        dbTransaction.Commit();
                        if (effectedRows > 0)
                        {
                            return new MyServiceResult
                            {
                                Successed = true,
                                Content = $"Xoá thành công Minh chứng {objMinhChungDPEntity.MaTieuChuan}"
                            };
                        }
                        else
                        {
                            return new MyServiceResult
                            {
                                Successed = false,
                                Content = $"Xoá thất bại Minh chứng {objMinhChungDPEntity.MaTieuChuan}"
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new MyServiceResult
                        {
                            Successed = false,
                            Content = ex.Message
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new MyServiceResult
                {
                    Successed = false,
                    Content = ex.Message
                };
            }
        }
    }
}