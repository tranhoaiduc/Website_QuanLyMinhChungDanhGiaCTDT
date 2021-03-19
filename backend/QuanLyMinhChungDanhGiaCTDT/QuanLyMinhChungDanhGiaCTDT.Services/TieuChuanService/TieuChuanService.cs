using AdminApp.Shared.ExtentionMethod;
using Dapper;
using QuanLyMinhChungDanhGiaCTDT.Dapper.Dapper;
using QuanLyMinhChungDanhGiaCTDT.Dapper.Dapper.Interface;
using QuanLyMinhChungDanhGiaCTDT.Models.DapperModels.MinhChungModel;
using QuanLyMinhChungDanhGiaCTDT.Models.DapperModels.TieuChuanModel;
using QuanLyMinhChungDanhGiaCTDT.Models.ResultModels;
using QuanLyMinhChungDanhGiaCTDT.Services.TieuChuanService.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace QuanLyMinhChungDanhGiaCTDT.Services.TieuChuanService
{
    public class TieuChuanService : ITieuChuanService
    {
        public readonly IMyDapper _IMyDapper;

        public TieuChuanService(IMyDapper iMyDapper)
        {
            _IMyDapper = iMyDapper;
        }

        public async Task<MyServiceResult> CapNhat(string maTieuChuan, CapNhatTieuChuanDPEntity model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maTieuChuan))
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Lỗi cập nhật Tiêu chuẩn"
                    };
                }

                if (model is null)
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Lỗi tạo Tiêu chuẩn"
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
                        TieuChuanDPEntity objTieuChuanDPEntity = await dbConnection.QueryFirstOrDefaultAsync<TieuChuanDPEntity>("[LayTieuChuanTheoMa]", new { @MaTieuChuan = maTieuChuan }, transaction: dbTransaction, commandType: CommandType.StoredProcedure);

                        if (objTieuChuanDPEntity is null)
                        {
                            return new MyServiceResult
                            {
                                Successed = false,
                                Content = "Không tìm thấy Tiêu chuẩn"
                            };
                        }

                        model.TenTieuChuan = model.TenTieuChuan.CapitalizeWord();
                        model.MoTa = model.MoTa.CapitalizeSentences();

                        int effectedRows = await dbConnection.ExecuteAsync("[CapNhatTieuChuan]", new { @MaTieuChuan = maTieuChuan, @TenTieuChuan = model.TenTieuChuan, @MoTa = model.MoTa, @SoHopMinhChung = model.SoHopMinhChung }, transaction: dbTransaction, commandType: CommandType.StoredProcedure);
                        dbTransaction.Commit();
                        if (effectedRows > 0)
                        {
                            return new MyServiceResult
                            {
                                Successed = true,
                                Content = $"Cập nhật thành công Tiêu chuẩn {objTieuChuanDPEntity.TenTieuChuan}"
                            };
                        }
                        else
                        {
                            return new MyServiceResult
                            {
                                Successed = false,
                                Content = $"Cập nhật thất bại Tiêu chuẩn {objTieuChuanDPEntity.TenTieuChuan}"
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
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MyServiceListObjectResult<TieuChuanDPEntity>> LayDanhSach()
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
                        IEnumerable<TieuChuanDPEntity> enumerableTieuChuanDPEntity = await dbConnection.QueryAsync<TieuChuanDPEntity>("[LayDanhSachTieuChuan]", transaction: iDbTransaction, commandType: CommandType.StoredProcedure);
                        iDbTransaction.Commit();
                        return new MyServiceListObjectResult<TieuChuanDPEntity>
                        {
                            Successed = true,
                            Content = "Lấy danh sách Tiêu chuẩn thành công",
                            ListObject = enumerableTieuChuanDPEntity
                        };
                    }
                    catch (Exception ex)
                    {
                        iDbTransaction.Rollback();
                        return new MyServiceListObjectResult<TieuChuanDPEntity>
                        {
                            Successed = false,
                            Content = ex.Message
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new MyServiceListObjectResult<TieuChuanDPEntity>
                {
                    Successed = false,
                    Content = ex.Message
                };
            }
        }

        public async Task<MyServiceObjectResult<TieuChuanDPEntity>> LayTheoMa(string maTieuChuan)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maTieuChuan))
                {
                    return new MyServiceObjectResult<TieuChuanDPEntity>
                    {
                        Successed = false,
                        Content = "Lỗi lấy Tiêu chuẩn"
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
                        TieuChuanDPEntity objTieuChuanDPEntity = await dbConnection.QueryFirstOrDefaultAsync<TieuChuanDPEntity>("[LayTieuChuanTheoMa]", new { @MaTieuChuan = maTieuChuan }, transaction: iDbTransaction, commandType: CommandType.StoredProcedure);

                        iDbTransaction.Commit();
                        if (objTieuChuanDPEntity is null)
                        {
                            return new MyServiceObjectResult<TieuChuanDPEntity>
                            {
                                Successed = false,
                                Content = "Không tìm thấy Tiêu chuẩn",
                                Object = null
                            };
                        }
                        else
                        {
                            return new MyServiceObjectResult<TieuChuanDPEntity>
                            {
                                Successed = true,
                                Content = "Lấy Tiêu chuẩn thành công",
                                Object = objTieuChuanDPEntity
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        iDbTransaction.Rollback();
                        return new MyServiceObjectResult<TieuChuanDPEntity>
                        {
                            Successed = false,
                            Content = ex.Message
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new MyServiceObjectResult<TieuChuanDPEntity>
                {
                    Successed = false,
                    Content = ex.Message
                };
            }
        }

        public async Task<MyServiceResult> Tao(TaoTieuChuanDPEntity model)
        {
            try
            {
                if (model is null)
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Lỗi tạo Tiêu chuẩn"
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
                        model.TenTieuChuan = model.TenTieuChuan.CapitalizeWord();
                        model.MoTa = model.MoTa.CapitalizeSentences();
                        int effectedRows = await dbConnection.ExecuteAsync("[TaoTieuChuan]", new { model.MaTieuChuan, model.TenTieuChuan, model.MoTa, model.SoHopMinhChung }, transaction: dbTransaction, commandType: CommandType.StoredProcedure);
                        dbTransaction.Commit();
                        if (effectedRows > 0)
                        {
                            return new MyServiceResult
                            {
                                Successed = true,
                                Content = $"Tạo thành công Tiêu chuẩn {model.TenTieuChuan}"
                            };
                        }
                        else
                        {
                            return new MyServiceResult
                            {
                                Successed = false,
                                Content = $"Tạo thất bại Tiêu chuẩn {model.TenTieuChuan}"
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

        public async Task<MyServiceResult> Xoa(string maTieuChuan)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maTieuChuan))
                {
                    return new MyServiceResult
                    {
                        Successed = false,
                        Content = "Lỗi xoá Tiêu chuẩn"
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
                        TieuChuanDPEntity objTieuChuanDPEntity = await dbConnection.QueryFirstOrDefaultAsync<TieuChuanDPEntity>("[LayTieuChuanTheoMa]", new { @MaTieuChuan = maTieuChuan }, transaction: dbTransaction, commandType: CommandType.StoredProcedure);
                        if (objTieuChuanDPEntity is null)
                        {
                            return new MyServiceResult
                            {
                                Successed = false,
                                Content = "Không tìm thấy Tiêu chuẩn"
                            };
                        }

                        int effectedRows = await dbConnection.ExecuteAsync("[XoaTieuChuan]", new { @MaTieuChuan = maTieuChuan }, transaction: dbTransaction, commandType: CommandType.StoredProcedure);
                        dbTransaction.Commit();
                        if (effectedRows > 0)
                        {
                            return new MyServiceResult
                            {
                                Successed = true,
                                Content = $"Xoá thành công Tiêu chuẩn {objTieuChuanDPEntity.TenTieuChuan}"
                            };
                        }
                        else
                        {
                            return new MyServiceResult
                            {
                                Successed = false,
                                Content = $"Xoá thất bại Tiêu chuẩn {objTieuChuanDPEntity.TenTieuChuan}"
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