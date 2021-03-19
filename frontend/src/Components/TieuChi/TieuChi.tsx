/* eslint-disable react-hooks/exhaustive-deps */
/* eslint-disable @typescript-eslint/no-unused-vars */

//#region Import

import {
  Button,
  Card,
  Input,
  message,
  Modal,
  Space,
  Table,
  Tag,
  Tooltip,
} from "antd";
import { SearchOutlined, UserAddOutlined } from "@ant-design/icons";
import React, { FC, useContext, useEffect, useRef, useState } from "react";
import { Header } from "../Global/Header";
import { BASE_URL } from "../../GlobalVariable";
import { ITieuChuan } from "../../Models/Interface/ITieuChuan";
import { Container } from "react-bootstrap";
import { ITieuChi } from "../../Models/Interface/ITieuChi";
import { IServiceListObjectResult } from "../../Models/Interface/IServiceListObjectResult";
import axios from "axios";
import { ThemTieuChuan } from "../TieuChuan/ThemTieuChuan";
import { ThemTieuChi } from "./ThemTieuChi";
import Parser from "html-react-parser";

//#endregion

//#region Interface

//#endregion

export const TieuChi: FC = () => {
  //#region State Variable

  const [tieuChiSource, setTieuChiSource] = useState<ITieuChi[]>([]);
  const [isShowThemTieuChi, setIsShowThemTieuChi] = useState<boolean>(false);

  //#endregion

  //#region Variable

  const columnsTable = [
    {
      title: "Mã qui tắc",
      width: 100,
      dataIndex: "MaQuiTac",
      align: "center" as "center",
      fixed: "left" as "left",
      render: (value: string) => {
        return <Tag color={"blue"}>{value}</Tag>;
      },
    },
    {
      title: "Tên Tiêu chí",
      width: 200,
      dataIndex: "TenTieuChi",
      align: "left" as "left",
      fixed: "left" as "left",
    },
    {
      title: "Mã Tiêu chí",
      width: 150,
      dataIndex: "MaTieuChi",
      align: "center" as "center",
      render: (value: string) => {
        return <Tag color={"blue"}>{value}</Tag>;
      },
    },
    {
      title: "Yêu cầu của Tiêu chí",
      width: 400,
      dataIndex: "YeuCauCuaTieuChi",
      align: "left" as "left",
      render: (text: string) => {
        return <>{Parser(text)}</>;
      },
    },
    {
      title: "Móc chuẩn tham chiếu để đánh giá Tiêu chí đạt chuẩn mức bốn",
      width: 450,
      dataIndex: "MocChuanThamChieuDeDanhGiaTieuChiDatMucBon",
      align: "left" as "left",
      render: (text: string) => {
        return <>{Parser(text)}</>;
      },
    },
    {
      title: "Gợi ý nguồn Minh chứng",
      width: 400,
      dataIndex: "GoiYNguonMinhChung",
      align: "left" as "left",
      render: (text: string) => {
        return <>{Parser(text)}</>;
      },
    },
    {
      title: "Tên Tiêu chuẩn",
      width: 200,
      dataIndex: "TenTieuChuan",
      fixed: "right" as "right",
      align: "center" as "center",
    },
    {
      title: "Thao tác",
      width: 120,
      dataIndex: "Operation",
      fixed: "right" as "right",
      align: "center" as "center",
      render: (text: any, record: any) => (
        <React.Fragment>
          <Button
            type="primary"
            style={{ width: "100%", marginBottom: "5px" }}
            onClick={() => {}}
          >
            Cập nhật
          </Button>
          <Button
            type="primary"
            danger
            style={{ width: "100%" }}
            onClick={() => {}}
          >
            Xoá
          </Button>
        </React.Fragment>
      ),
    },
  ];

  //#endregion

  //#region Effect

  useEffect(() => {
    getListTieuChi();
  }, []);

  //#endregion

  //#region Function

  function getListTieuChi() {
    axios
      .get<IServiceListObjectResult<ITieuChi>>(
        `${BASE_URL}/api/v1/tieu-chi/lay-danh-sach`
      )
      .then((response) => {
        if (response.status === 200) {
          if (response.data.Successed === true) {
            let resource = response.data.ListObject.map((value: ITieuChi) => {
              return {
                ...value,
                MaQuiTac: `H${value.SoHopMinhChung}.${
                  value.MaTieuChuan.length < 2
                    ? `0${value.MaTieuChuan}`
                    : value.MaTieuChuan
                }.${
                  value.MaTieuChi.length < 2
                    ? `0${value.MaTieuChi}`
                    : value.MaTieuChi
                }`,
              };
            });
            setTieuChiSource(resource);
          }
        }
      });
  }

  //#endregion

  //#region Render

  return (
    <>
      <Header
        Title="Quản lý Tiêu chí"
        ObjectDescription={{
          CountingUsers: 0,
          CountActiveUsers: 0,
        }}
        MarginBottom="15"
        MarginTop="10"
      ></Header>
      <Card
        title="Danh sách Tiêu chí"
        style={{ width: "100%" }}
        extra={
          <React.Fragment>
            <Space>
              <Input
                placeholder="Từ khoá"
                style={{ height: "40px", minWidth: "300px" }}
              />
              <Tooltip title="Tìm kiếm">
                <Button
                  type="primary"
                  icon={<SearchOutlined />}
                  size={"large"}
                  style={{
                    display: "flex",
                    flexFlow: "row nowrap",
                    alignItems: "center",
                  }}
                >
                  Tìm kiếm
                </Button>
              </Tooltip>
              <Tooltip title="Thêm Tiêu chí">
                <Button
                  type="ghost"
                  icon={<UserAddOutlined />}
                  size={"large"}
                  style={{
                    display: "flex",
                    flexFlow: "row nowrap",
                    alignItems: "center",
                  }}
                  onClick={() => {
                    setIsShowThemTieuChi(true);
                  }}
                >
                  Thêm Tiêu chí
                </Button>
              </Tooltip>
            </Space>
          </React.Fragment>
        }
      >
        <Table
          rowKey="MaTieuChi"
          columns={columnsTable}
          dataSource={tieuChiSource}
          scroll={{ x: "100%", y: 500 }}
        ></Table>
      </Card>
      {isShowThemTieuChi && (
        <ThemTieuChi
          IsShowThemTieuChi={(value) => {
            setIsShowThemTieuChi(value);
          }}
        />
      )}
    </>
  );

  //#endregion
};
