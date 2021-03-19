import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import React, { FC, useState } from "react";
import { Col, Container, Row } from "react-bootstrap";
import { NavbarLeft } from "./NavbarLeft";
import { MinhChung } from "../MinhChung/MinhChung";
import { TieuChuan } from "../TieuChuan/TieuChuan";
import { TieuChi } from "../TieuChi/TieuChi";
import { TepTin } from "../TepTin/TepTin";
import { TrangChu } from "../TrangChu/TrangChu";

export const LayoutGlobal: FC = () => {
  const [dropdownCollapsed, setDropdownCollapsed] = useState(false);
  const [navbarCollapsed, setNavbarCollapsed] = useState(false);

  function handlerEventCollapsed(isCollapsed: boolean): void {
    setNavbarCollapsed(isCollapsed);
  }

  return (
    <Router>
      <Container fluid style={{ height: "100vh" }}>
        <Row style={{ height: "100vh" }}>
          <Col
            sm={4}
            md={navbarCollapsed ? 1 : 2 || 2}
            style={{ padding: 0, backgroundColor: "#001529" }}
          >
            <NavbarLeft onCollapsed={handlerEventCollapsed} />
          </Col>
          <Col
            id="mainContent"
            sm={8}
            md={navbarCollapsed ? 11 : 10 || 10}
            style={{ backgroundColor: "white" }}
          >
            <Switch>
              <Route exact path="/">
                <TrangChu />
              </Route>
              <Route path="/quan-ly/minh-chung">
                <MinhChung />
              </Route>
              <Route path="/quan-ly/tieu-chuan">
                <TieuChuan />
              </Route>
              <Route path="/quan-ly/tieu-chi">
                <TieuChi />
              </Route>
              <Route path="/quan-ly/tep-tin">
                <TepTin />
              </Route>
            </Switch>
          </Col>
        </Row>
      </Container>
    </Router>
  );
};
