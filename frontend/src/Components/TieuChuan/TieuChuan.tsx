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
import { ThemTieuChuan } from "./ThemTieuChuan";
import axios from "axios";
import { ITieuChuan } from "../../Models/Interface/ITieuChuan";
import { IServiceListObjectResult } from "../../Models/Interface/IServiceListObjectResult";

//#endregion

//#region Interface

//#endregion

export const TieuChuan: FC = () => {
  //#region State Variable

  const [isShowThemTieuChuan, setIsShowThemTieuChuan] = useState<boolean>(
    false
  );

  const [tieuChuanSource, setTieuChuanSource] = useState<ITieuChuan[]>([]);

  //#endregion

  //#region Varibale

  const columnsTable = [
    {
      title: "Mã Tiêu chuẩn",
      width: 200,
      dataIndex: "MaTieuChuan",
      align: "center" as "center",
      render: (value: string) => {
        return <Tag color={"blue"}>{value}</Tag>;
      },
    },
    {
      title: "Tên Tiêu chuẩn",
      width: 200,
      dataIndex: "TenTieuChuan",
      align: "center" as "center",
    },
    {
      title: "Mô tả",
      width: 200,
      dataIndex: "MoTa",
      align: "center" as "center",
      render: (value: string) => {
        return value === "" ? (
          <Tag color={"warning"}>Trống</Tag>
        ) : (
          <span>{value}</span>
        );
      },
    },
    {
      title: "Số hộp Minh chứng",
      width: 200,
      dataIndex: "SoHopMinhChung",
      align: "center" as "center",
      render: (value: string) => {
        return <Tag color={"geekblue"}>{value}</Tag>;
      },
    },
    {
      title: "Thao tác",
      width: 150,
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
    getListTieuChuan();
  }, []);

  //#endregion

  //#region Function

  function getListTieuChuan() {
    axios
      .get<IServiceListObjectResult<ITieuChuan>>(
        `${BASE_URL}/api/v1/tieu-chuan/lay-danh-sach`
      )
      .then((response) => {
        if (response.status === 200) {
          if (response.data.Successed === true) {
            setTieuChuanSource(response.data.ListObject);
          }
        }
      });
  }

  //#endregion

  return (
    <>
      <Header
        Title="Quản lý Tiêu chuẩn"
        ObjectDescription={{
          CountingUsers: 0,
          CountActiveUsers: 0,
        }}
        MarginBottom="15"
        MarginTop="10"
      ></Header>
      <Card
        title="Danh sách Tiêu chuẩn"
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
              <Tooltip title="Thêm Tiêu chuẩn">
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
                    setIsShowThemTieuChuan(true);
                  }}
                >
                  Thêm Tiêu chuẩn
                </Button>
              </Tooltip>
            </Space>
          </React.Fragment>
        }
      >
        <Table
          rowKey="Id"
          columns={columnsTable}
          dataSource={tieuChuanSource}
          scroll={{ x: "100%", y: 400 }}
        ></Table>
      </Card>
      {isShowThemTieuChuan && (
        <ThemTieuChuan
          IsShowThemTieuChuan={(value) => {
            setIsShowThemTieuChuan(value);
          }}
          GetListTieuChuan={() => {
            getListTieuChuan();
          }}
        />
      )}
    </>
  );
  //#endregion
};
