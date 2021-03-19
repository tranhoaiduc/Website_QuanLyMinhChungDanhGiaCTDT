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
  Tooltip,
} from "antd";
import { SearchOutlined, UserAddOutlined } from "@ant-design/icons";
import React, { FC, useContext, useEffect, useRef, useState } from "react";
import { Header } from "../Global/Header";
import { BASE_URL } from "../../GlobalVariable";

//#endregion

//#region Interface

export interface PropertiesColumn {
  key: string;
  id: string;
  fullName: string;
  userName: string;
  dateOfBirth?: string;
  dateRegister: string;
  email: string;
  emailConfirmed: boolean;
  phoneNumber: string;
  phoneNumberConfirmed: boolean;
  address?: string;
  isActive: boolean;
  lastSignIn?: string;
}

export interface IStateDeleteUser {
  IsRender: boolean;
  IsShow: boolean;
  QuickInfo: {
    Id: string;
    UserName: string;
    FullName: string;
    Email: string;
    PhoneNumber: string;
  };
}

export interface IStateUserUpdate {
  IsRender: boolean;
  QuickInfo: {
    UserId: string;
  };
}

//#endregion

export const MinhChung: FC = () => {
  //#region Context

  // const { userAuthen, setUserAuthen } = useContext<IUserAuthenContext>(
  //   AuthenContext
  // );

  //#endregion

  //#region  My State

  const [confirmLoading, setConfirmLoading] = React.useState(false);

  //#endregion

  //#region Variable

  const columnsTable = [
    {
      title: "STT",
      width: 200,
      dataIndex: "STT",
      fixed: "left" as "left",
      align: "center" as "center",
    },
    {
      title: "Mã Minh chứng",
      width: 200,
      dataIndex: "MaMinhChung",
      fixed: "left" as "left",
      align: "center" as "center",
    },
    {
      title: "Số ký hiệu",
      width: 150,
      dataIndex: "SoKyHieu",
      align: "center" as "center",
    },
    {
      title: "Trích yếu",
      width: 300,
      dataIndex: "TrichYeu",
      align: "center" as "center",
    },
    {
      title: "Ngày nhận",
      width: 150,
      dataIndex: "NgayNhan",
      align: "center" as "center",
    },
    {
      title: "Cơ quan ban hành",
      width: 200,
      dataIndex: "CoQuanBanHanh",
      align: "center" as "center",
    },
    {
      title: "Nơi nhận các văn bản",
      width: 200,
      dataIndex: "NoiNhanCacVanBan",
      align: "center" as "center",
    },
    {
      title: "Người ký văn bản",
      width: 200,
      dataIndex: "NguoiKyVanBan",
      align: "center" as "center",
    },
    {
      title: "Số phát hành",
      width: 200,
      dataIndex: "SoPhatHanh",
      align: "center" as "center",
    },
    {
      title: "Lĩnh vực văn bản",
      width: 200,
      dataIndex: "LinhVucVanBan",
      align: "center" as "center",
    },
    {
      title: "Loại văn bản",
      width: 200,
      dataIndex: "LoaiVanBan",
      align: "center" as "center",
    },
    {
      title: "Ngày tạo",
      width: 200,
      dataIndex: "NgayTao",
      align: "center" as "center",
    },
    {
      title: "Người tạo",
      width: 200,
      dataIndex: "NguoiTao",
      align: "center" as "center",
    },
    {
      title: "Tiêu chuẩn",
      width: 200,
      dataIndex: "TieuChuan",
      align: "center" as "center",
    },
    {
      title: "Tiêu chí",
      width: 200,
      dataIndex: "TieuChi",
      align: "center" as "center",
    },
    {
      title: "Mức độ",
      width: 200,
      dataIndex: "MucDo",
      align: "center" as "center",
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

  return (
    <>
      <Header
        Title="Quản lý Minh chứng"
        ObjectDescription={{
          CountingUsers: 0,
          CountActiveUsers: 0,
        }}
        MarginBottom="15"
        MarginTop="10"
      ></Header>
      <Card
        title="Danh sách Minh chứng"
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
              <Tooltip title="Thêm Minh chứng">
                <Button
                  type="ghost"
                  icon={<UserAddOutlined />}
                  size={"large"}
                  style={{
                    display: "flex",
                    flexFlow: "row nowrap",
                    alignItems: "center",
                  }}
                  onClick={() => {}}
                >
                  Thêm Minh chứng
                </Button>
              </Tooltip>
            </Space>
          </React.Fragment>
        }
      >
        <Table
          rowKey="Id"
          columns={columnsTable}
          scroll={{ x: 1000, y: 500 }}
        ></Table>
      </Card>
    </>
  );
  //#endregion
};
