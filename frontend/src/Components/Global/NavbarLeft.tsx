//#region Import

import React, { useState, FC } from "react";
import { Menu, Button, Tooltip } from "antd";
import {
  AppstoreOutlined,
  MenuUnfoldOutlined,
  MenuFoldOutlined,
  PieChartOutlined,
  MailOutlined,
} from "@ant-design/icons";
import {
  BoxMenu,
  BoxTitle,
  BoxTitleText,
  BoxUser,
  BoxUserAvatar,
  BoxUserAvatarImage,
  BoxUserInfo,
  BoxUserInfoInline,
  BoxUserInfoText,
  NavbarLeftContainer,
} from "../../Styles/Styled/NavbarLeftStyled.module";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faEnvelope,
  faUser,
  faAddressCard,
  faCircle,
  faSignOutAlt,
} from "@fortawesome/free-solid-svg-icons";
import "../../Styles/NavbarLeft.css";
//#endregion

const { SubMenu } = Menu;

export const NavbarLeft: FC<{ onCollapsed: any }> = ({ onCollapsed }) => {
  const [collapsed, setCollapsed] = useState(false);

  function handlerMenuCollapsedClick(): void {
    setCollapsed(!collapsed);
    onCollapsed(!collapsed);
  }

  return (
    <NavbarLeftContainer>
      <BoxTitle>
        <BoxTitleText className={collapsed ? "boxTitleCollapsed" : ""}>
          Quản lý Minh chứng
        </BoxTitleText>
      </BoxTitle>
      <BoxUser className={collapsed ? "boxUserCollapsed" : ""}>
        <BoxUserAvatar>
          <BoxUserAvatarImage
            src="https://via.placeholder.com/100"
            alt="Avatar"
          />
        </BoxUserAvatar>
        <BoxUserInfo style={{ display: collapsed ? "none" : "flex" }}>
          <Tooltip title={`Họ tên: Trần Hoài Đức`} placement="right">
            <BoxUserInfoInline>
              <FontAwesomeIcon icon={faUser} size="lg" color="white" />
              <BoxUserInfoText>Trần Hoài Đức</BoxUserInfoText>
            </BoxUserInfoInline>
          </Tooltip>
          <Tooltip
            title={`Email: Readingcrossfire@gmail.com`}
            placement="right"
          >
            <BoxUserInfoInline>
              <FontAwesomeIcon icon={faEnvelope} size="1x" color="white" />
              <BoxUserInfoText>Readingcrossfire@gmail.com</BoxUserInfoText>
            </BoxUserInfoInline>
          </Tooltip>
          <Tooltip title={`Chức vụ: Administrator`} placement="right">
            <BoxUserInfoInline>
              <FontAwesomeIcon icon={faAddressCard} size="1x" color="white" />
              <BoxUserInfoText>Administrator</BoxUserInfoText>
            </BoxUserInfoInline>
          </Tooltip>
          <Tooltip title="Trạng thái: Đang hoạt động" placement="right">
            <BoxUserInfoInline>
              <FontAwesomeIcon
                className="font-awesome-custom"
                icon={faCircle}
                size="sm"
                color="green"
              />
              <BoxUserInfoText>Hoạt động</BoxUserInfoText>
            </BoxUserInfoInline>
          </Tooltip>
          <Tooltip title="Đăng xuất" placement="right">
            <BoxUserInfoInline>
              <FontAwesomeIcon
                className="font-awesome-custom"
                icon={faSignOutAlt}
                size="1x"
                color="white"
              />
              <BoxUserInfoText>Đăng xuất</BoxUserInfoText>
            </BoxUserInfoInline>
          </Tooltip>
        </BoxUserInfo>
      </BoxUser>
      <BoxMenu>
        <div style={{ width: "100%" }}>
          <Button
            type="primary"
            onClick={handlerMenuCollapsedClick}
            style={{ marginBottom: 16, width: "100%" }}
          >
            {React.createElement(
              collapsed ? MenuUnfoldOutlined : MenuFoldOutlined
            )}
          </Button>
          <Menu
            defaultSelectedKeys={[""]}
            defaultOpenKeys={["ManageMenu"]}
            mode="inline"
            theme="dark"
            inlineCollapsed={collapsed}
            style={{ height: "calc(100vh - 268px)", width: "100%" }}
          >
            <Menu.Item
              key="1"
              icon={<PieChartOutlined />}
              style={{ width: "100%" }}
            >
              <Link to="/">Trang chủ</Link>
            </Menu.Item>
            <SubMenu key="ManageMenu" icon={<MailOutlined />} title="Quản lý">
              <Menu.Item key="2" style={{ width: "100%" }}>
                <Link to="/quan-ly/minh-chung">Minh chứng</Link>
              </Menu.Item>
              <Menu.Item key="3" style={{ width: "100%" }}>
                <Link to="/quan-ly/tieu-chuan">Tiêu chuẩn</Link>
              </Menu.Item>
              <Menu.Item key="4" style={{ width: "100%" }}>
                <Link to="/quan-ly/tieu-chi">Tiêu chí</Link>
              </Menu.Item>
              <Menu.Item key="5" style={{ width: "100%" }}>
                <Link to="/quan-ly/tep-tin">Tệp tin</Link>
              </Menu.Item>
            </SubMenu>
          </Menu>
        </div>
      </BoxMenu>
    </NavbarLeftContainer>
  );
};

// export default NavbarLeft;
