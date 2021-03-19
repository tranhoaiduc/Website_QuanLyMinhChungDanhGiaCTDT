//#region

import {
  Button,
  Card,
  Col,
  Form,
  Input,
  notification,
  Radio,
  Row,
  Spin,
} from "antd";
import { RequiredMark } from "antd/lib/form/Form";
import axios from "axios";
import React, { FC, useEffect, useState } from "react";
import { Row as RowBS, Col as ColBS, Container } from "react-bootstrap";
import { BASE_URL } from "../../GlobalVariable";
import { IServiceResult } from "../../Models/Interface/IServiceResult";
import { ITieuChuan } from "../../Models/Interface/ITieuChuan";

//#endregion

//#region Interface

interface IThemTieuChuanProps {
  IsShowThemTieuChuan: (value: boolean) => void;
  GetListTieuChuan: () => void;
}

//#endregion

export const ThemTieuChuan: FC<IThemTieuChuanProps> = ({
  IsShowThemTieuChuan,
  GetListTieuChuan,
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

  const [isShowLoading, setIsShowLoading] = useState<boolean>(false);
  const [isDisableSubmit, setIsDisableSubmit] = useState<boolean>(false);

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

  //#endregion

  //#region Function

  async function handleFormSubmit() {
    if (
      formProperties.MaTieuChuan === "" ||
      formProperties.MaTieuChuan === null
    ) {
      notification["error"]({
        message: "Lỗi",
        description: "Mã Tiêu chuẩn không được bỏ trống",
      });
    } else if (
      formProperties.TenTieuChuan === "" ||
      formProperties.TenTieuChuan === null
    ) {
      notification["error"]({
        message: "Lỗi",
        description: "Tên Tiêu chuẩn không được bỏ trống",
      });
    } else if (
      formProperties.TenTieuChuan === "" ||
      formProperties.TenTieuChuan === null
    ) {
      notification["error"]({
        message: "Lỗi",
        description: "Tên Tiêu chuẩn không được bỏ trống",
      });
    } else if (
      formProperties.SoHopMinhChung === "" ||
      formProperties.SoHopMinhChung === null
    ) {
      notification["error"]({
        message: "Lỗi",
        description: "Số hộp minh chứng không được bỏ trống",
      });
    } else {
      setIsDisableSubmit(true);
      setIsShowLoading(true);
      axios
        .post<IServiceResult>(
          `${BASE_URL}/api/v1/tieu-chuan/tao`,
          JSON.stringify({
            MaTieuChuan: formProperties.MaTieuChuan,
            TenTieuChuan: formProperties.TenTieuChuan,
            MoTa: formProperties.MoTa,
            SoHopMinhChung: formProperties.SoHopMinhChung,
          }),
          {
            headers: {
              "Content-Type": "application/json",
            },
          }
        )
        .then((response) => {
          setIsDisableSubmit(false);
          setIsShowLoading(false);
          if (response.status === 200) {
            if (response.data.Successed === true) {
              handleClearForm();
              notification["success"]({
                message: "Thêm Tiêu chuẩn",
                description: response.data.Content,
              });
            } else {
              notification["false"]({
                message: "Thêm Tiêu chuẩn",
                description: response.data.Content,
              });
            }
          } else {
            notification["false"]({
              message: "Thêm Tiêu chuẩn",
              description: response.statusText,
            });
          }
        });
    }
  }

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

  function handleClearForm() {
    setFormProperties({
      MaTieuChuan: "",
      TenTieuChuan: "",
      MoTa: "",
      SoHopMinhChung: "",
    });
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
            position: "relative",
          }}
        >
          <Card
            title="Thêm Tiêu chuẩn"
            style={{
              border: "1px solid rgb(0, 120, 220)",
              boxShadow: "0 0 10px rgba(0, 120, 220, 0.5)",
            }}
            className="custom-card custom-card-total"
            extra={
              <Radio.Button
                value="large"
                onClick={() => {
                  GetListTieuChuan();
                  IsShowThemTieuChuan(false);
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
                        <Form.Item
                          label="Mã Tiêu chuẩn"
                          tooltip="Mã Tiêu chuẩn không được bỏ trống"
                          // rules={[
                          //   {
                          //     required: true,
                          //     message: "Mã Tiêu chuẩn không được bỏ trống",
                          //   },
                          //   {
                          //     validator: async (rule, value: string) => {
                          //       let valueNumber: number = parseInt(value);
                          //       if (valueNumber < 1) {
                          //         throw new Error(
                          //           "Mã Tiêu chuẩn không được nhỏ hơn 1"
                          //         );
                          //       }
                          //       if (valueNumber > 100) {
                          //         throw new Error(
                          //           "Mã Tiêu chuẩn không được lớn hơn 100"
                          //         );
                          //       }
                          //     },
                          //   },
                          // ]}
                        >
                          <Input
                            name="matieuchuan"
                            placeholder="Mã Tiêu chuẩn"
                            type="number"
                            min={1}
                            max={100}
                            value={formProperties?.MaTieuChuan}
                            onChange={handleInputChange}
                          />
                        </Form.Item>
                        <Form.Item
                          label="Tên Tiêu chuẩn"
                          required
                          // tooltip="Tên Tiêu chuẩn không được bỏ trống"
                          // rules={[
                          //   {
                          //     required: true,
                          //     message: "Tên Tiêu chuẩn không được bỏ trống",
                          //   },
                          // ]}
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
                          // tooltip="Mô tả không được bỏ trống"
                          // rules={[
                          //   {
                          //     required: true,
                          //     message: "Mô tả không được bỏ trống",
                          //   },
                          // ]}
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
                          // tooltip="Số hộp Minh chứng không được bỏ trống"
                          // rules={[
                          //   {
                          //     required: true,
                          //     message: "Số hộp Minh chứng không được bỏ trống",
                          //   },
                          //   {
                          //     validator: async (rule, value: string) => {
                          //       let valueNumber: number = parseInt(value);
                          //       if (valueNumber < 1) {
                          //         throw new Error(
                          //           "Số hộp Minh chứng không được nhỏ hơn 1"
                          //         );
                          //       }
                          //       if (valueNumber > 100) {
                          //         throw new Error(
                          //           "Số hộp Minh chứng không được lớn hơn 100"
                          //         );
                          //       }
                          //     },
                          //   },
                          // ]}
                        >
                          <Input
                            name="sohopminhchung"
                            placeholder="Số hộp Minh chứng"
                            value={formProperties?.SoHopMinhChung}
                            type="number"
                            min={1}
                            max={100}
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
                            disabled={isDisableSubmit}
                          >
                            Thêm tiêu chuẩn
                          </Button>
                        </Form.Item>
                      </Card>
                    </Col>
                  </Row>
                </div>
              </Card>
            </Form>
          </Card>
          <div
            className="cLoading"
            style={{
              height: "100%",
              width: "100%",
              display: isShowLoading === true ? "block" : "none",
              position: "absolute",
              top: "50%",
              left: "50%",
              transform: "translate(-50%, -50%)",
              zIndex: 999,
              backgroundColor: "rgba(255, 255, 255, 0.5)",
            }}
          >
            <Spin
              size="large"
              style={{
                position: "absolute",
                top: "50%",
                left: "50%",
                transform: "translate(-50%, -50%)",
                zIndex: 999,
              }}
            />
          </div>
        </ColBS>
      </RowBS>
    </Container>
  );

  //#endregion
};
