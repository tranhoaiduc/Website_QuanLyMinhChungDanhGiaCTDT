using AdminApp.Shared.ExtentionMethod;
using Dapper;
using QuanLyMinhChungDanhGiaCTDT.Dapper.Dapper.Interface;
using QuanLyMinhChungDanhGiaCTDT.Models.DapperModels.TieuChiModel;
using QuanLyMinhChungDanhGiaCTDT.Models.ResultModels;
using QuanLyMinhChungDanhGiaCTDT.Services.TieuChiService.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace QuanLyMinhChungDanhGiaCTDT.Services.TieuChiService
{
    public class TieuChiService : ITieuChiService
    {
        public readonly IMyDapper _IMyDapper;

        public TieuChiService(IMyDapper iMyDapper)
        {
            _IMyDapper = iMyDapper;
        }

        public async Task<MyServiceResult> CapNhat(string maTieuChi, CapNhatTieuChiDPEntity model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maTieuChi))
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Lỗi cập nhật Tiêu chí"
                    };
                }

                if (model is null)
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Lỗi cập nhật Tiêu chí"
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
                        TieuChiDPEntity objTieuChiDPEntity = await dbConnection.QueryFirstOrDefaultAsync<TieuChiDPEntity>("[LayTieuChiTheoMa]", new { @MaTieuChi = maTieuChi }, transaction: dbTransaction, commandType: CommandType.StoredProcedure);

                        if (objTieuChiDPEntity is null)
                        {
                            return new MyServiceResult
                            {
                                Successed = false,
                                Content = "Không tìm thấy Tiêu chí"
                            };
                        }

                        int effectedRows = await dbConnection.ExecuteAsync("[CapNhatTieuChi]", new { @MaTieuChi = maTieuChi, @TenTieuChi = model.TenTieuChi, @YeuCauCuaTieuChi = model.YeuCauCuaTieuChi, @MocChuanThamChieuDeDanhGiaTieuChiDatMucBon = model.MocChuanThamChieuDeDanhGiaTieuChiDatMucBon, @GoiYNguonMinhChung = model.GoiYNguonMinhChung, @MaTieuChuan = model.MaTieuChuan }, transaction: dbTransaction, commandType: CommandType.StoredProcedure);
                        dbTransaction.Commit();
                        if (effectedRows > 0)
                        {
                            return new MyServiceResult
                            {
                                Successed = true,
                                Content = $"Cập nhật thành công Tiêu chí {objTieuChiDPEntity.TenTieuChi}"
                            };
                        }
                        else
                        {
                            return new MyServiceResult
                            {
                                Successed = false,
                                Content = $"Cập nhật thất bại Tiêu chí {objTieuChiDPEntity.TenTieuChi}"
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

        public async Task<MyServiceListObjectResult<TieuChiDPEntity>> LayDanhSach()
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
                        IEnumerable<TieuChiDPEntity> enumerableTieuChiDPEntity = await dbConnection.QueryAsync<TieuChiDPEntity>("[LayDanhSachTieuChi]", transaction: iDbTransaction, commandType: CommandType.StoredProcedure);
                        iDbTransaction.Commit();
                        return new MyServiceListObjectResult<TieuChiDPEntity>
                        {
                            Successed = true,
                            Content = "Lấy danh sách Tiêu chí thành công",
                            ListObject = enumerableTieuChiDPEntity
                        };
                    }
                    catch (Exception ex)
                    {
                        iDbTransaction.Rollback();
                        return new MyServiceListObjectResult<TieuChiDPEntity>
                        {
                            Successed = false,
                            Content = ex.Message
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new MyServiceListObjectResult<TieuChiDPEntity>
                {
                    Successed = false,
                    Content = ex.Message
                };
            }
        }

        public async Task<MyServiceObjectResult<TieuChiDPEntity>> LayTheoMa(string maTieuChi)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maTieuChi))
                {
                    return new MyServiceObjectResult<TieuChiDPEntity>
                    {
                        Successed = false,
                        Content = "Lỗi lấy Tiêu chí"
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
                        TieuChiDPEntity objTieuChiDPEntity = await dbConnection.QueryFirstOrDefaultAsync<TieuChiDPEntity>("[LayTieuChiTheoMa]", new { @MaTieuChi = maTieuChi }, transaction: iDbTransaction, commandType: CommandType.StoredProcedure);

                        iDbTransaction.Commit();
                        if (objTieuChiDPEntity is null)
                        {
                            return new MyServiceObjectResult<TieuChiDPEntity>
                            {
                                Successed = false,
                                Content = "Không tìm thấy Tiêu chí",
                                Object = null
                            };
                        }
                        else
                        {
                            return new MyServiceObjectResult<TieuChiDPEntity>
                            {
                                Successed = true,
                                Content = "Lấy Tiêu chí thành công",
                                Object = objTieuChiDPEntity
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        iDbTransaction.Rollback();
                        return new MyServiceObjectResult<TieuChiDPEntity>
                        {
                            Successed = false,
                            Content = ex.Message
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new MyServiceObjectResult<TieuChiDPEntity>
                {
                    Successed = false,
                    Content = ex.Message
                };
            }
        }

        public async Task<MyServiceResult> Tao(TaoTieuChiDPEntity model)
        {
            try
            {
                if (model is null)
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Lỗi tạo Tiêu chí"
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
                        int effectedRows = await dbConnection.ExecuteAsync("[TaoTieuChi]", new { @MaTieuChi = model.MaTieuChi, @TenTieuChi = model.TenTieuChi, @YeuCauCuaTieuChi = model.YeuCauCuaTieuChi, @MocChuanThamChieuDeDanhGiaTieuChiDatMucBon = model.MocChuanThamChieuDeDanhGiaTieuChiDatMucBon, @GoiYNguonMinhChung = model.GoiYNguonMinhChung, model.MaTieuChuan }, transaction: dbTransaction, commandType: CommandType.StoredProcedure);
                        dbTransaction.Commit();
                        if (effectedRows > 0)
                        {
                            return new MyServiceResult
                            {
                                Successed = true,
                                Content = $"Tạo thành công Tiêu chí {model.TenTieuChi}"
                            };
                        }
                        else
                        {
                            return new MyServiceResult
                            {
                                Successed = false,
                                Content = $"Tạo thất bại Tiêu chí {model.TenTieuChi}"
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

        public async Task<MyServiceResult> Xoa(string maTieuChi)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maTieuChi))
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Lỗi xoá Tiêu chí"
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
                        TieuChiDPEntity objTieuChiDPEntity = await dbConnection.QueryFirstOrDefaultAsync<TieuChiDPEntity>("[LayTieuChiTheoMa]", new { @MaTieuChi = maTieuChi }, transaction: dbTransaction, commandType: CommandType.StoredProcedure);
                        if (objTieuChiDPEntity is null)
                        {
                            return new MyServiceResult
                            {
                                Successed = false,
                                Content = "Không tìm thấy Tiêu chí"
                            };
                        }

                        int effectedRows = await dbConnection.ExecuteAsync("[XoaTieuChi]", new { @MaTieuChi = maTieuChi }, transaction: dbTransaction, commandType: CommandType.StoredProcedure);
                        dbTransaction.Commit();
                        if (effectedRows > 0)
                        {
                            return new MyServiceResult
                            {
                                Successed = true,
                                Content = $"Xoá thành công Tiêu chí {objTieuChiDPEntity.TenTieuChi}"
                            };
                        }
                        else
                        {
                            return new MyServiceResult
                            {
                                Successed = false,
                                Content = $"Xoá thất bại Tiêu chí {objTieuChiDPEntity.TenTieuChi}"
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