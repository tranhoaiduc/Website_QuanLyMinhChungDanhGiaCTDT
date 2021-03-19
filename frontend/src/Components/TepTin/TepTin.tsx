/* eslint-disable react-hooks/exhaustive-deps */
/* eslint-disable @typescript-eslint/no-unused-vars */

//#region Import

import {
  Avatar,
  Button,
  Card,
  Input,
  List,
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
import DirectoryTree from "antd/lib/tree/DirectoryTree";

export const TepTin: FC = () => {
  const treeData = [
    {
      title: "parent 0",
      key: "0",
      children: [
        { title: "leaf 0-0", key: "0-0", isLeaf: false },
        { title: "leaf 0-1", key: "0-1", isLeaf: false },
      ],
    },
    {
      title: "parent 1",
      key: "1",
      children: [
        { title: "leaf 1-0", key: "1-0", isLeaf: false },
        { title: "leaf 1-1", key: "1-1", isLeaf: false },
      ],
    },
    {
      title: "parent 1",
      key: "2",
      children: [
        { title: "leaf 1-0", key: "2-0", isLeaf: false },
        { title: "leaf 1-1", key: "2-1", isLeaf: false },
      ],
    },
  ];
  const data = [
    {
      title: "Ant Design Title 1",
    },
    {
      title: "Ant Design Title 2",
    },
    {
      title: "Ant Design Title 3",
    },
    {
      title: "Ant Design Title 4",
    },
    {
      title: "Ant Design Title 4",
    },
    {
      title: "Ant Design Title 4",
    },
  ];
  const onSelect = (keys: React.Key[], info: any) => {
    console.log("Trigger Select", keys, info);
  };

  const onExpand = () => {
    console.log("Trigger Expand");
  };
  return (
    <>
      <Header
        Title="Quản lý Tệp tin"
        ObjectDescription={{
          CountingUsers: 0,
          CountActiveUsers: 0,
        }}
        MarginBottom="15"
        MarginTop="10"
      ></Header>
      <Card title="Danh sách Tệp tin" style={{ width: "100%" }}>
        <Card.Grid
          hoverable={false}
          style={{ height: "500px", width: "50%", overflow: "auto" }}
        >
          <DirectoryTree
            multiple
            defaultExpandAll
            onSelect={onSelect}
            onExpand={onExpand}
            treeData={treeData}
          />
        </Card.Grid>
        <Card.Grid
          hoverable={false}
          style={{ height: "500px", width: "50%", overflow: "auto" }}
        >
          <List
            style={{ width: "50%" }}
            itemLayout="horizontal"
            dataSource={data}
            renderItem={(item) => (
              <List.Item>
                <List.Item.Meta
                  avatar={
                    <Avatar src="https://zos.alipayobjects.com/rmsportal/ODTLcjxAfvqbxHnVXCYX.png" />
                  }
                  title={<a href="https://ant.design">{item.title}</a>}
                  description="Ant Design, a design language for background applications, is refined by Ant UED Team"
                />
              </List.Item>
            )}
          />
        </Card.Grid>
      </Card>
    </>
  );
  //#endregion
};
