import { Button, Card, Col, Form, Input, Radio, Row } from "antd";
import { RequiredMark } from "antd/lib/form/Form";
import React, { FC, useEffect, useState } from "react";
import { Row as RowBS, Col as ColBS, Container } from "react-bootstrap";
import { ITieuChuan } from "../../Models/Interface/ITieuChuan";

interface ICapNhatTieuChuanProps {
  MaTieuChuan: string;
  IsShowCapNhatTieuChuan: (value: boolean) => void;
  LayDanhSachTieuChuan: () => void;
}

export const CapNhatTieuChuan: FC<ICapNhatTieuChuanProps> = ({
  MaTieuChuan,
  IsShowCapNhatTieuChuan,
}) => {
  //#region State

  const [requiredMark, setRequiredMarkType] = useState<RequiredMark>(
    "optional"
  );

  const [formProperties, setFormProperties] = useState<ITieuChuan>({
    MaTieuChuan: "",
    TenTieuChuan: "",
    MoTa: "",
    SoHopMinhChung: "1",
  });

  //#endregion

  //#region Variable

  const [form] = Form.useForm();

  const onRequiredTypeChange = ({
    requiredMark,
  }: {
    requiredMark: RequiredMark;
  }) => {
    setRequiredMarkType(requiredMark);
  };

  //#endregion

  //#region Effect

  useEffect(() => {}, []);

  //#endregion

  //#region Function

  async function handleFormSubmit() {}

  function handleInputChange(event: React.ChangeEvent<HTMLInputElement>): void {
    if (event.target.name === "matieuchuan") {
      setFormProperties({
        ...formProperties,
        MaTieuChuan: event.target.value,
      });
    } else if (event.target.name === "tentieuchuan") {
      setFormProperties({
        ...formProperties,
        TenTieuChuan: event.target.value,
      });
    } else if (event.target.name === "mota") {
      setFormProperties({
        ...formProperties,
        MoTa: event.target.value,
      });
    } else if (event.target.name === "sohopminhchung") {
      setFormProperties({
        ...formProperties,
        SoHopMinhChung: event.target.value,
      });
    }
  }

  //#endregion

  //#region Render

  return (
    <Container
      fluid
      style={{
        height: "100vh",
        display: "block",
        backgroundColor: "rgba(255, 255, 255, 0.8)",
        position: "fixed",
        top: 0,
        left: 0,
        zIndex: 999,
      }}
    >
      <RowBS style={{ height: "100%" }} className="justify-content-md-center">
        <ColBS
          md={6}
          style={{
            display: "flex",
            flexFlow: "column nowrap",
            justifyContent: "center",
          }}
        >
          <Card
            title="C???p nh???t Ti??u chu???n"
            style={{
              border: "1px solid rgb(0, 120, 220)",
              boxShadow: "0 0 10px rgba(0, 120, 220, 0.5)",
            }}
            className="custom-card custom-card-total"
            extra={
              <Radio.Button
                value="large"
                onClick={() => {
                  IsShowCapNhatTieuChuan(false);
                }}
              >
                X
              </Radio.Button>
            }
          >
            <Form
              form={form}
              layout="vertical"
              initialValues={{ requiredMark }}
              onValuesChange={onRequiredTypeChange}
              requiredMark={requiredMark}
              onFinish={handleFormSubmit}
            >
              <Card title="Th??ng tin" style={{ marginTop: "10px" }}>
                <div className="site-card-wrapper">
                  <Row gutter={24}>
                    <Col span={24}>
                      <Card bordered={false}>
                        <Form.Item label="M?? Ti??u chu???n" name="matieuchuan">
                          <Input
                            placeholder="M?? Ti??u chu???n"
                            value={formProperties?.MaTieuChuan}
                            disabled={true}
                          />
                        </Form.Item>
                        <Form.Item
                          label="T??n Ti??u chu???n"
                          required
                          tooltip="T??n Ti??u chu???n kh??ng ???????c b??? tr???ng"
                          rules={[
                            {
                              required: true,
                              message: "T??n Ti??u chu???n kh??ng ???????c b??? tr???ng",
                            },
                          ]}
                        >
                          <Input
                            name="tentieuchuan"
                            placeholder="T??n Ti??u chu???n"
                            value={formProperties?.TenTieuChuan}
                            onChange={handleInputChange}
                          />
                        </Form.Item>
                        <Form.Item
                          label="M?? t???"
                          required
                          tooltip="M?? t??? kh??ng ???????c b??? tr???ng"
                          rules={[
                            {
                              required: true,
                              message: "M?? t??? kh??ng ???????c b??? tr???ng",
                            },
                          ]}
                        >
                          <Input
                            name="mota"
                            placeholder="M?? t???"
                            value={formProperties?.MoTa}
                            onChange={handleInputChange}
                          />
                        </Form.Item>
                        <Form.Item
                          label="S??? h???p Minh ch???ng"
                          required
                          tooltip="S??? h???p Minh ch???ng kh??ng ???????c b??? tr???ng"
                          rules={[
                            {
                              required: true,
                              message: "S??? h???p Minh ch???ng kh??ng ???????c b??? tr???ng",
                            },
                          ]}
                        >
                          <Input
                            name="sohopminhchung"
                            placeholder="S??? h???p Minh ch???ng"
                            value={formProperties?.SoHopMinhChung}
                            type="number"
                            onChange={handleInputChange}
                          />
                        </Form.Item>
                      </Card>
                    </Col>
                    <Col span={24}>
                      <Card bordered={false}>
                        <Form.Item>
                          <Button
                            htmlType="submit"
                            type="primary"
                            style={{ height: "40px", width: "100%" }}
                            disabled={false}
                          >
                            C???p nh???t ti??u chu???n
                          </Button>
                        </Form.Item>
                      </Card>
                    </Col>
                  </Row>
                </div>
              </Card>
            </Form>
          </Card>
        </ColBS>
      </RowBS>
    </Container>
  );

  //#endregion
};
