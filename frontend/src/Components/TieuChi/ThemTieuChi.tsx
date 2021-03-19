//#region

import {
  Button,
  Card,
  Col,
  Empty,
  Form,
  Input,
  Radio,
  RadioChangeEvent,
  Row,
  Space,
} from "antd";
import { RequiredMark } from "antd/lib/form/Form";
import React, { FC, useEffect, useState } from "react";
import { Row as RowBS, Col as ColBS, Container } from "react-bootstrap";
import { ITaoTieuChi } from "../../Models/Interface/ITaoTieuChi";
import { CKEditor } from "@ckeditor/ckeditor5-react";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import "../../Styles/GlobalStyle.css";
import TextArea from "antd/lib/input/TextArea";
import { ITieuChuan } from "../../Models/Interface/ITieuChuan";
import axios from "axios";
import { IServiceListObjectResult } from "../../Models/Interface/IServiceListObjectResult";
import { BASE_URL } from "../../GlobalVariable";
import { IServiceResult } from "../../Models/Interface/IServiceResult";

//#endregion

//#region Interface

interface IThemTieuChiProps {
  IsShowThemTieuChi: (value: boolean) => void;
}

//#endregion

export const ThemTieuChi: FC<IThemTieuChiProps> = ({ IsShowThemTieuChi }) => {
  //#region State

  const [requiredMark, setRequiredMarkType] = useState<RequiredMark>(
    "optional"
  );

  const [tieuChuanSource, setTieuChuanSource] = useState<
    ITieuChuan[] | undefined
  >(undefined);

  const [formProperties, setFormProperties] = useState<ITaoTieuChi>({
    MaTieuChi: "",
    TenTieuChi: "",
    GoiYNguonMinhChung: "",
    YeuCauCuaTieuChi: "",
    MocChuanThamChieuDeDanhGiaTieuChiDatMucBon: "",
    MaTieuChuan: "",
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

  //#endregion Effect

  useEffect(() => {
    getListTieuChuan();
  }, []);

  useEffect(() => {
    console.log(formProperties);
  }, [formProperties]);

  //#endregion

  //#region Function

  async function handleFormSubmit() {
    axios
      .post<IServiceResult>(
        `${BASE_URL}/api/v1/tieu-chi/tao`,
        JSON.stringify({
          MaTieuChi: formProperties.MaTieuChi,
          TenTieuChi: formProperties.TenTieuChi,
          YeuCauCuaTieuChi: formProperties.YeuCauCuaTieuChi,
          MocChuanThamChieuDeDanhGiaTieuChiDatMucBon:
            formProperties.MocChuanThamChieuDeDanhGiaTieuChiDatMucBon,
          GoiYNguonMinhChung: formProperties.GoiYNguonMinhChung,
          MaTieuChuan: formProperties.MaTieuChuan,
        }),
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      )
      .then((response) => {
        console.log(response.data);
      });
  }

  function handleInputChange(
    event:
      | React.ChangeEvent<HTMLInputElement>
      | RadioChangeEvent
      | React.ChangeEvent<HTMLTextAreaElement>
  ): void {
    if (event.target.name === "matieuchi") {
      setFormProperties({
        ...formProperties,
        MaTieuChi: event.target.value,
      });
    } else if (event.target.name === "tentieuchi") {
      setFormProperties({
        ...formProperties,
        TenTieuChi: event.target.value,
      });
    } else if (event.target.name === "tieuchuan") {
      setFormProperties({ ...formProperties, MaTieuChuan: event.target.value });
    }
  }

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
            title="Thêm Tiêu chí"
            style={{
              border: "1px solid rgb(0, 120, 220)",
              boxShadow: "0 0 10px rgba(0, 120, 220, 0.5)",
            }}
            className="custom-card custom-card-total"
            extra={
              <Radio.Button
                value="large"
                onClick={() => {
                  IsShowThemTieuChi(false);
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
                          label="Mã Tiêu chí"
                          required
                          tooltip="Mã Tiêu chí không được bỏ trống"
                          rules={[
                            {
                              required: true,
                              message: "Mã Tiêu chí không được bỏ trống",
                            },
                          ]}
                        >
                          <Input
                            name="matieuchi"
                            placeholder="Mã Tiêu chí"
                            value={formProperties?.MaTieuChi}
                            onChange={handleInputChange}
                          />
                        </Form.Item>
                        <Form.Item
                          label="Tên Tiêu chí"
                          required
                          tooltip="Tên Tiêu chí không được bỏ trống"
                          rules={[
                            {
                              required: true,
                              message: "Tên Tiêu chí không được bỏ trống",
                            },
                          ]}
                        >
                          <TextArea
                            autoSize={{ minRows: 3, maxRows: 9 }}
                            name="tentieuchi"
                            placeholder="Tên Tiêu chí"
                            value={formProperties?.TenTieuChi}
                            onChange={handleInputChange}
                          />
                        </Form.Item>
                        <Form.Item
                          label="Yêu cầu của Tiêu chí"
                          required
                          tooltip="Yêu cầu của Tiêu chí không được bỏ trống"
                          rules={[
                            {
                              required: true,
                              message:
                                "Yêu cầu của Tiêu chí không được bỏ trống",
                            },
                          ]}
                        >
                          <CKEditor
                            editor={ClassicEditor}
                            data=""
                            name="yeucaucautieuchi"
                            config={{
                              toolbar: [
                                "bold",
                                "italic",
                                "link",
                                "undo",
                                "redo",
                                "numberedList",
                                "bulletedList",
                              ],
                              placeholder: "Yêu cầu của Tiêu chí",
                            }}
                            onReady={(editor) => {}}
                            onChange={(event, editor) => {
                              const data = editor.getData();
                              setFormProperties({
                                ...formProperties,
                                YeuCauCuaTieuChi: data,
                              });
                            }}
                            onBlur={(event, editor) => {}}
                            onFocus={(event, editor) => {}}
                          />
                        </Form.Item>
                        <Form.Item
                          label="Mốc chuẩn tham chiếu để đánh giá Tiêu chí đạt mức bốn"
                          name="mocchuanthamchieudedanhgiatieuchidatmucbon"
                          required
                          tooltip="Không được bỏ trống"
                          rules={[
                            {
                              required: true,
                              message: "Không được bỏ trống",
                            },
                          ]}
                        >
                          <CKEditor
                            editor={ClassicEditor}
                            data=""
                            config={{
                              toolbar: [
                                "bold",
                                "italic",
                                "link",
                                "undo",
                                "redo",
                                "numberedList",
                                "bulletedList",
                              ],
                              placeholder:
                                "Mốc chuẩn tham chiếu để đánh giá Tiêu chí đạt mức bốn",
                            }}
                            onReady={(editor) => {}}
                            onChange={(event, editor) => {
                              const data = editor.getData();
                              setFormProperties({
                                ...formProperties,
                                MocChuanThamChieuDeDanhGiaTieuChiDatMucBon: data,
                              });
                            }}
                            onBlur={(event, editor) => {}}
                            onFocus={(event, editor) => {}}
                          />
                        </Form.Item>
                        <Form.Item
                          label="Gợi ý nguồn minh chứng"
                          required
                          tooltip="Không được bỏ trống"
                          rules={[
                            {
                              required: true,
                              message: "Không được bỏ trống",
                            },
                          ]}
                        >
                          <CKEditor
                            editor={ClassicEditor}
                            data=""
                            config={{
                              toolbar: [
                                "bold",
                                "italic",
                                "link",
                                "undo",
                                "redo",
                                "numberedList",
                                "bulletedList",
                              ],
                              placeholder: "Gợi ý nguồn minh chứng",
                            }}
                            onReady={(editor) => {}}
                            onChange={(event, editor) => {
                              const data = editor.getData();
                              setFormProperties({
                                ...formProperties,
                                GoiYNguonMinhChung: data,
                              });
                            }}
                            onBlur={(event, editor) => {}}
                            onFocus={(event, editor) => {}}
                          />
                        </Form.Item>
                        <Form.Item
                          label="Tiêu chuẩn"
                          required
                          tooltip="Tiêu chuẩn không được bỏ trống"
                          rules={[
                            {
                              required: true,
                              message: "Tiêu chuẩn không được bỏ trống",
                            },
                          ]}
                        >
                          {tieuChuanSource === undefined ? (
                            <Empty />
                          ) : (
                            <Radio.Group
                              name="tieuchuan"
                              buttonStyle="solid"
                              style={{ width: "100%" }}
                              onChange={handleInputChange}
                            >
                              {tieuChuanSource.map((value) => (
                                <Row gutter={24}>
                                  <Col span={24}>
                                    <Radio.Button
                                      style={{ width: "100%", margin: "5px 0" }}
                                      value={value.MaTieuChuan}
                                    >
                                      {value.TenTieuChuan}
                                    </Radio.Button>
                                  </Col>
                                </Row>
                              ))}
                            </Radio.Group>
                          )}
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
                            Thêm Tiêu chí
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
