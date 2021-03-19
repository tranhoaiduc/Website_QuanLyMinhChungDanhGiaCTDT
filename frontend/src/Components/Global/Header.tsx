import { Descriptions } from "antd";
import PageHeader from "antd/lib/page-header";
import React, { FC } from "react";

class HeaderProps {
  Title: string | undefined;
  SubTitle?: string;
  ObjectDescription: {} = {
    CountingUsers: "",
    CountActiveUsers: "",
  };
  MarginTop: string | undefined;
  MarginBottom: string | undefined;
}

export const Header: FC<HeaderProps> = ({
  Title,
  SubTitle,
  ObjectDescription,
  MarginTop,
  MarginBottom,
}) => {
  return (
    <PageHeader
      ghost={false}
      title={Title}
      subTitle={SubTitle}
      style={{
        marginTop: MarginTop + "px",
        marginBottom: MarginBottom + "px",
      }}
    >
      {/* <Descriptions size="middle">
        <Descriptions.Item
          label="Số lượng người dùng"
          style={{ fontWeight: "bold" }}
        ></Descriptions.Item>
        <Descriptions.Item
          label="Số lượng người dùng đang hoạt động"
          style={{ fontWeight: "bold" }}
        ></Descriptions.Item>
      </Descriptions> */}
    </PageHeader>
  );
};
