import React from "react";
import { Form, Input } from "antd";
import DashboardTemplate from "../../components/dashboard-template";

function ManageCategory() {
  const columns = [
    {
      title: "Id",
      dataIndex: "categoryId",
      key: "categoryId",
    },

    {
      title: "Name",
      dataIndex: "categoryName",
      key: "categoryName",
    },
  ];

  const formItems = (
    <>
      <Form.Item name="categoryName" label="Name">
        <Input />
      </Form.Item>
    </>
  );

  return (
    <DashboardTemplate
      columns={columns}
      apiURI="categories"
      formItems={formItems}
      idName="categoryId"
    />
  );
}

export default ManageCategory;
