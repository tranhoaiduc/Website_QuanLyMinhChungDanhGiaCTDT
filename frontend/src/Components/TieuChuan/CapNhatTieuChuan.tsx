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
            title="Cập nhật Tiêu chuẩn"
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
              <Card title="Thông tin" style={{ marginTop: "10px" }}>
                <div className="site-card-wrapper">
                  <Row gutter={24}>
                    <Col span={24}>
                      <Card bordered={false}>
                        <Form.Item label="Mã Tiêu chuẩn" name="matieuchuan">
                          <Input
                            placeholder="Mã Tiêu chuẩn"
                            value={formProperties?.MaTieuChuan}
                            disabled={true}
                          />
                        </Form.Item>
                        <Form.Item
                          label="Tên Tiêu chuẩn"
                          required
                          tooltip="Tên Tiêu chuẩn không được bỏ trống"
                          rules={[
                            {
                              required: true,
                              message: "Tên Tiêu chuẩn không được bỏ trống",
                            },
                          ]}
                        >
                          <Input
                            name="tentieuchuan"
                            placeholder="Tên Tiêu chuẩn"
                            value={formProperties?.TenTieuChuan}
                            onChange={handleInputChange}
                          />
                        </Form.Item>
                        <Form.Item
                          label="Mô tả"
                          required
                          tooltip="Mô tả không được bỏ trống"
                          rules={[
                            {
                              required: true,
                              message: "Mô tả không được bỏ trống",
                            },
                          ]}
                        >
                          <Input
                            name="mota"
                            placeholder="Mô tả"
                            value={formProperties?.MoTa}
                            onChange={handleInputChange}
                          />
                        </Form.Item>
                        <Form.Item
                          label="Số hộp Minh chứng"
                          required
                          tooltip="Số hộp Minh chứng không được bỏ trống"
                          rules={[
                            {
                              required: true,
                              message: "Số hộp Minh chứng không được bỏ trống",
                            },
                          ]}
                        >
                          <Input
                            name="sohopminhchung"
                            placeholder="Số hộp Minh chứng"
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
                            Cập nhật tiêu chuẩn
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
