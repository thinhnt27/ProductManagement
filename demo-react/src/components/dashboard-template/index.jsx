import { Button, Form, Input, Modal, Popconfirm, Table } from "antd";
import React, { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { useForm } from "antd/es/form/Form";
import dayjs from "dayjs";
import api from "../../config/axios";

function DashboardTemplate({
  columns,
  apiURI,
  formItems,
  idName,
}) {
  const [categories, setCategories] = useState([]);
  const [open, setOpen] = useState(false);
  const [form] = useForm();
  const [loading, setLoading] = useState(false);
  const [isFetching, setIsFetching] = useState(true);

  const fetchCategory = async () => {
    try {
      const response = await api.get(apiURI);
      setIsFetching(false);
      setCategories(response.data);
    } catch (err) {
      toast.error(err.response.data);
    }
  };

  const handleSubmit = async (values) => {
    setLoading(true);
    console.log(values)
    try {
      if (values[idName]) {
        // Update
        await api.put(`${apiURI}/${values[idName]}`, values);
      } else {
        // Create
        await api.post(apiURI, values);
      }

      toast.success("Create new category success!");
      setOpen(false);
      fetchCategory();
    } catch (err) {
      toast.error(err.response.data);
    }
    setLoading(false);
  };

  const handleDelete = async (id) => {
    console.log(id)
    try {
      await api.delete(`${apiURI}/${id}`);
      toast.success("Delete category success!");
      fetchCategory();
    } catch (err) {
      toast.error(err.response.data);
    }
  };

  useEffect(() => {
    fetchCategory();
  }, []);

  return (
    <div>
      <Button
        onClick={() => {
          form.resetFields();
          setOpen(true);
        }}
        style={{
          marginBottom: 16,
        }}
        type="primary"
      >
        Create
      </Button>
      <Table
        columns={[
          ...columns,
          {
            title: "Action",
            key: "action",
            render: (record) => (
              <>
                <Button
                  type="primary"
                  onClick={() => {
                    setOpen(true);
                    const newRecord = { ...record };

                    for (let key of Object.keys(newRecord)) {
                      const value = newRecord[key];
                      const date = new Date(value);
                      const time = date.getTime();

                      if (typeof value === "number" || isNaN(time)) {
                        newRecord[key] = value;
                      } else {
                        newRecord[key] = dayjs(value);
                      }
                    }

                    form.setFieldsValue(newRecord);
                  }}
                >
                  Edit
                </Button>
                <Popconfirm
                  title="Delete"
                  description={`Are you sure to delete ${record.name}?`}
                  onConfirm={() => handleDelete(record[idName])}
                >
                  <Button type="primary" danger>
                    Delete
                  </Button>
                </Popconfirm>
              </>
            ),
          },
        ]}
        dataSource={categories}
        loading={isFetching}
      />
      <Modal
        title="Create new category"
        open={open}
        onCancel={() => setOpen(false)}
        footer={[
          <Button key="cancel" onClick={() => setOpen(false)}>Cancel</Button>,
          <Button
            key="save"
            type="primary"
            onClick={() => form.submit()}
            loading={loading}
          >
            Save
          </Button>,
        ]}
      >
        <Form
          labelCol={{ span: 24 }}
          onFinish={handleSubmit}
          form={form}
        >
          <Form.Item name={idName} label="ID" hidden>
            <Input />
          </Form.Item>
          {formItems}
        </Form>
      </Modal>
    </div>
  );
}

export default DashboardTemplate;
